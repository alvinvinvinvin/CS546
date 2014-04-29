using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemModel
{
    public class Project
    {
        public Guid projectID { get; set; }
        public Guid? departmentID{get; set;}
        public Guid? employeeID { get; set; }
        public decimal? timeperiod { get; set; }
    }
}
