using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemModel
{
    public class Participation
    {
        public Guid participatingID { get; set; }
        public Guid? projectID { get; set; }
        public Guid employeeID { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? quitDate { get; set; }
    }
}
