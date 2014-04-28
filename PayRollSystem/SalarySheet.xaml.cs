using PayRollSystemDAL;
using PayRollSystemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PayRollSystem
{
    /// <summary>
    /// Interaction logic for SalarySheet.xaml
    /// </summary>
    /// 

    
    public partial class SalarySheet : Window
    {
        public SalarySheet()
        {
            InitializeComponent();
        }
        public string editerRank { get; set; }
        public Guid editerDptID { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> listYears = new List<int>();
            for (int i = DateTime.Now.Year - 5; i < DateTime.Now.Year + 5; i++)
            {
                listYears.Add(i);
            }
            List<int> listmonth = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                listmonth.Add(i);
            }
            cmbYear.ItemsSource = listYears;
            cmbMonth.ItemsSource = listmonth;

            cmbYear.SelectedValue = DateTime.Now.Year;
            cmbMonth.SelectedValue = DateTime.Now.Month;

            cmbDepartment.ItemsSource = new DepartmentDAL().ListAll();
            if (editerRank == "Manager")
            {
                cmbDepartment.SelectedValue = editerDptID;
                cmbDepartment.Visibility = Visibility.Hidden;
            }
        }

        private void btnGenerateSheet_Click(object sender, RoutedEventArgs e)
        {
            int year = (int)cmbYear.SelectedValue;
            int month = (int)cmbMonth.SelectedValue;
            Guid deptId = (Guid)cmbDepartment.SelectedValue;
            SalarySheetDAL dal = new SalarySheetDAL();
            if (dal.IsExisted(year, month, deptId))
            {
                if (MessageBoxResult.Yes == MessageBox.Show("SalarySheet is already existed. Do you want to gernerate one again?",
                                 "Warning", MessageBoxButton.YesNo))
                {
                    dal.Clear(year, month, deptId);
                    dal.Generate(year, month, deptId);
                    //MessageBox.Show("Successful Generating!");
                    colEmployee.ItemsSource = new EmployeeDAL().SearchByDpt(deptId);
                    datagrid.ItemsSource =
                    new SalarySheetItemDAL().GetItemsByDate(year, month, deptId);
                }
                else
                {
                    return;
                }
            }
            else
            {
                dal.Generate(year, month, deptId);
                colEmployee.ItemsSource = new EmployeeDAL().SearchByDpt(deptId);
                datagrid.ItemsSource = 
                    new SalarySheetItemDAL().GetItemsByDate(year, month, deptId);
            }
        }

        private void datagrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            SalarySheetItem item = (SalarySheetItem)e.Row.DataContext;
            Guid EmployeeID = item.EmployeeID;
            EmployeeDAL employdal = new EmployeeDAL();
            Employee employee = employdal.GetEmployeeByID(EmployeeID);
            BaseSalaryRangeDAL BsrDAL = new BaseSalaryRangeDAL();
            decimal uperLimit = new BaseSalaryRangeDAL().GetBaseSalaryUperLimitByRankID(employee);
            decimal lowerLimit = new BaseSalaryRangeDAL().GetBaseSalaryLowerLimitByRankID(employee);
            decimal basesalary = item.BaseSalary;
            if (basesalary <= uperLimit && basesalary >= lowerLimit)
            {
                new SalarySheetDAL().Update(item);
            }
            else
            {
                MessageBox.Show("BaseSalary is out of range!");
                return;
            }
        }

    }
}
