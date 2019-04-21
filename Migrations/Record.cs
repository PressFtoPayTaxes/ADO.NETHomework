using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    public class Record
    {
        public Guid Id { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime LeavingTime { get; set; }
        public string ClientName { get; set; }
        public int PassportNumber { get; set; }
        public string VisitPurpose { get; set; }

        public Record()
        {
            Id = Guid.NewGuid();
        }
    }
}
