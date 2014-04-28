using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemModel
{
    public class SalarySheet
    {
        public Guid SalarySheetID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public Guid DepartmentID { get; set; }
    }
}
