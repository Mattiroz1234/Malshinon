using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Ocsp;

namespace Malshinon
{
    internal class Handler 
    {
        public static void Menu()
        {
            Console.WriteLine("enter your first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("enter your last name: ");
            string lastName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length < 3 ||
                string.IsNullOrWhiteSpace(lastName) || lastName.Length < 3)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            int reporterId = IdReq(firstName, lastName, "reporter"); 
            Person reporter = PersonDAL.GetPerson(reporterId);


            Console.WriteLine("enter your report: ");
            string report = Console.ReadLine();

            string[] names = RepoValid.Valid(report);
            if (names == null)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            int targetId = IdReq(names[0], names[1], "target");
            Person target = PersonDAL.GetPerson(targetId);

            ReportDAL.AddReport(reporterId, targetId, report);

            UpdateDetails(reporter, target);

            CreateAlerts(target);

        }


        private static int IdReq(string firstName, string lastName, string type)
        {
            int id = PersonDAL.GetPersonId(firstName, lastName);
            if (id == 0)
            {
                PersonDAL.AddPerson(firstName, lastName, type);
                id = PersonDAL.GetPersonId(firstName, lastName);
            }
            return id;
        }


        private static void UpdateDetails(Person rep, Person tar)
        {
            if(rep.Type == "target")
            {
                PersonDAL.UpdateType(rep.Id, "both"); 
            }

            if (tar.Type == "reporter")
            {
                PersonDAL.UpdateType(tar.Id, "both");
            }

            PersonDAL.UpdateReportsNum(rep.Id);
            PersonDAL.UpdateMentionsNum(tar.Id);

            CheckType(rep);
        }


        private static void CheckType(Person rep)
        {
            if (rep.NumReports > 10)
            {
                if (ReportDAL.GetAverage(rep.Id) > 100)
                {
                    PersonDAL.UpdateType(rep.Id, "potential agent");
                }
            }
            else
            {
                if (rep.Type == "potential agent")
                {
                    if (rep.NumMentions > 0)
                    {
                        PersonDAL.UpdateType(rep.Id, "both");
                    }
                    else
                    {
                        PersonDAL.UpdateType(rep.Id, "reporter");
                    }
                }
            }
        }


        private static void CreateAlerts(Person tar)
        {
            if (tar.NumMentions < 20)
            {
                AlertDAL.AddAlert(tar.Id, "It has more than 20 reports.");
            }

            if (ReportDAL.CheckInLast15Min(tar.Id) >= 3)
            {
                AlertDAL.AddAlert(tar.Id, "Rapid reports detected.");
            }
        }
    }
}
