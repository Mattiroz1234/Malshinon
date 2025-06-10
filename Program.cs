using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PersonDAL.UpdateType(4, "both");
            int a = PersonDAL.GetPersonId("matt", "rosenfeld");
            Console.WriteLine(a);
            Person p = PersonDAL.GetPerson(a);
            Console.WriteLine(p.SecretCode);



        }
    }
}
