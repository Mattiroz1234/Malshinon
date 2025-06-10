using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Person
    {
        internal int Id;
        internal string FirstName;
        internal string LastName;
        internal string SecretCode;
        internal string Type;
        internal int NumReports;
        internal int NumMentions;

        public Person(int id, string firstName, string lastName, string secretCode, string type, int numReports, int numMentions)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SecretCode = secretCode;
            Type = type;
            NumReports = numReports;
            NumMentions = numMentions;
        }
    }
}
