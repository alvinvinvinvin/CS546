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
    /// Interaction logic for ProjectEditWindow.xaml
    /// </summary>
    public partial class ProjectEditWindow : Window
    {
        public Project prj;
        public Department dpt;

        public ProjectEditWindow()
        {
            InitializeComponent();
        }

        public void loadAllEmployee()
        {
            datagrid.ItemsSource = new EmployeeDAL().ListAll();
        }

        public void loadAllParticipators()
        {
            EmployeeDAL empDAL = new EmployeeDAL();
            ProjectDAL prjDAL = new ProjectDAL();
            participationDAL partiDAL = new participationDAL();
            Employee[] dptEmployees = empDAL.listByDepartment(dpt.DepartmentID);
            //Employee[] test = dptEmployees;
            //Project prjTest = prj;
            for (int i = 0; i < dptEmployees.Length; i++)
            {
                if (prjDAL.IsParticipatorExisted(prj, dptEmployees[i]))
                {
                    dptEmployees[i].IsSelected = true;
                }
                else dptEmployees[i].IsSelected = false;
                
            }
            
            datagrid.ItemsSource = dptEmployees;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProjectDAL prjDAL = new ProjectDAL();
            colRankId.ItemsSource = new RankDAL().ListAll();
            colDepartmentId.ItemsSource = new DepartmentDAL().ListAll();
            loadAllParticipators();
            gridPrj.DataContext = prj;
            txtPeriod.Text = prjDAL.countPeriod(prj).ToString();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

            Employee[] employeesToChange = (Employee[])datagrid.ItemsSource;
            participationDAL partiDAL = new participationDAL();

            for (int i = 0; i < employeesToChange.Length; i++)
            {
                if (employeesToChange[i].IsSelected)
                {
                    employeesToChange[i].startDate = dpStartEmp.SelectedDate;
                    employeesToChange[i].quitDate = dpQuitEmp.SelectedDate;
                    partiDAL.updateDateByEmp(prj, employeesToChange[i], employeesToChange[i].startDate, employeesToChange[i].quitDate);
                }
            }
            colRankId.ItemsSource = new RankDAL().ListAll();
            colDepartmentId.ItemsSource = new DepartmentDAL().ListAll();
            loadAllParticipators();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ProjectDAL prjDAL = new ProjectDAL();
            participationDAL pariDAL = new participationDAL();
            Employee[] employeesToInsert = (Employee[])datagrid.ItemsSource;
            for (int i = 0; i < employeesToInsert.Length; i++)
            {
                if (employeesToInsert[i].IsSelected)
                {
                    if (prjDAL.IsParticipatorExisted(prj, employeesToInsert[i]))
                    {
                        continue;
                    }
                    else
                    {
                        prjDAL.insertEmployeeToPrj(prj, employeesToInsert[i]);
                    }
                } 
            }
            prj.costinwage = prjDAL.costInWage(prj) * prjDAL.countPeriod(prj);
            prjDAL.updatePrj(prj);
            
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProjectDAL prjDAL = new ProjectDAL();
            participationDAL pariDAL = new participationDAL();
            Employee[] employeesToInsert = (Employee[])datagrid.ItemsSource;
            for (int i = 0; i < employeesToInsert.Length; i++)
            {
                if (employeesToInsert[i].IsSelected)
                {
                    if (prjDAL.IsParticipatorExisted(prj, employeesToInsert[i]))
                    {
                        continue;
                    }
                    else
                    {
                        employeesToInsert[i].startDate = dpStartEmp.SelectedDate;
                        employeesToInsert[i].quitDate = dpQuitEmp.SelectedDate;
                        prjDAL.insertEmployeeToPrj(prj, employeesToInsert[i]);
                    }
                }
            }
           
        }

    }
}
