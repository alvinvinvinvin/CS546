using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemModel
{
    public class Department:INotifyPropertyChanged
    {
        public Guid DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public Guid? DepartmentManagerID { get; set; }
        public bool IsDeleted { get; set; }
        private bool isSelected;
        public bool IsSelected 
        {
            get 
            { 
                return isSelected; 
            }
            set 
            { 
                this.isSelected = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
