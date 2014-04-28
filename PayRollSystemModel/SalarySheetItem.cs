using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemModel
{
    public class SalarySheetItem
    {
        public Guid SalarySheetItemID { get; set; }
        public Guid SalarySheetID { get; set; }
        public Guid EmployeeID { get; set; }
        private decimal numBaseSalary;
        private decimal numBonus;
        private decimal numAfterTaxWage;
        private decimal numDeduction;

        public decimal BaseSalary
        {
            get { return numBaseSalary; }
            set { numBaseSalary = value; }
        }
        public decimal Bonus
        {
            get { return numBonus; }
            set { numBonus = value; }
        }
        public decimal Deduction
        {
            get { return numDeduction; }
            set { numDeduction = value; }
        }
        public decimal AfterTaxWage
        {
            get { return numAfterTaxWage = (numBaseSalary + numBonus) - numDeduction; }
            set { numAfterTaxWage = (numBaseSalary + numBonus) - numDeduction; }
        }
        
    }
}
