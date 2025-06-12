using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Alert
    {
        internal int Id;
        internal int TargetId;
        internal DateTime DateTime;
        internal string Reason;

        public Alert(int id, int targetId, DateTime dateTime, string reason)
        {
            Id = id;
            TargetId = targetId;
            DateTime = dateTime;
            Reason = reason;
        }
    }
}
