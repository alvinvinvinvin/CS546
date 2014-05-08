using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemModel
{
    public class Employee : INotifyPropertyChanged
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public Guid GenderID { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public Guid DepartmentID { get; set; }
        public Guid RankID { get; set; }
        public bool IsDeleted { get; set; }
        //public Guid? ManagerID { get; set; }
        public string ManagerName { get; set; }
        public string PaidFreq { get; set; }

        public DateTime? startDate { get; set; }
        public DateTime? quitDate { get; set; }
        //public Guid BaseSalaryRangeID { get; set; }

        //private decimal numBaseSalary;
        //private decimal numBonus;
        //private decimal numAfterTaxWage;
        //private decimal numDeduction;

        public decimal? BaseSalary
        {
            get;
            set;
        }
        public decimal? Bonus
        {
            get;
            set;
        }
        public decimal? AfterTaxWage
        {
            get;
            set;
        }
        public decimal? Deduction
        {
            get;
            set;
        }        
        public DateTime? LastPaidDate { get; set; }
        private bool isSelected;
        public bool IsSelected 
        { 
            get { return isSelected; }
            set
            {
                this.isSelected = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
