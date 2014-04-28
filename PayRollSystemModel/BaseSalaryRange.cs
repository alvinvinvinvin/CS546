using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemModel
{
    public class BaseSalaryRange
    {
        public Guid BaseSalaryRangeID { get; set; }
        public Guid RankID { get; set; }
        public decimal BaseSalaryUperLimit { get; set; }
        public decimal BaseSalaryLowerLimit { get; set; }
        public string RankName { get; set; }
    }
}
