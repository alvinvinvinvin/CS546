using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemModel
{
    public class Project:INotifyPropertyChanged
    {
        
        public Guid projectID { get; set; }
        public string projectName { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? dueDate { get; set; }
        private decimal? wageValue;
        private decimal? otherValue;
        private decimal? totalValue;
        public int? period { get; set; }
        public decimal? costinwage 
        {
            get { return wageValue; }
            set { wageValue = value; } 
        }
        public decimal? costinother 
        {
            get { return otherValue; }
            set { otherValue = value; }
        }
        public decimal? cost 
        {
            get { return totalValue = wageValue + otherValue; }
            set { totalValue = wageValue + otherValue; } 
        }
        public string description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
