using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Report
    {
        internal int Id;
        internal int ReporterId;
        internal int TargetId;
        internal string Text;
        internal DateTime DateTime;

        public Report(int id, int reporterId, int targetId, string text, DateTime dateTime)
        {
            Id = id;
            ReporterId = reporterId;
            TargetId = targetId;
            Text = text;
            DateTime = dateTime;
        }
    }
}
