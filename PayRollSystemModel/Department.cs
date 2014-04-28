using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemModel
{
    public class Department
    {
        public Guid DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public Guid? DepartmentManagerID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
