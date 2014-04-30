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
        public string projectName { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? dueDate { get; set; }
        public decimal? cost { get; set; }
    }
}
