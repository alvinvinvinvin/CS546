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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PayRollSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public string LoginerRankName { get; set; }
        public Guid LoginerID { get; set; }

        //being used for search manager
        public Guid LoginerDepartmentID { get; set; }

        //Load all data on datagrid
        public void LoadData()
        {
            datagrid.ItemsSource = new EmployeeDAL().ListAll();
        }

        //Load Loginer's data on datagrid
        public void LoadSingleData()
        {
            datagrid.ItemsSource = new EmployeeDAL().ListSingleData(LoginerID);
        }

        //Load Loginer's same department's workmates on datagrid, for manager
        public void LoadDepartmentData()
        {
            datagrid.ItemsSource = new EmployeeDAL().SearchByDpt(LoginerDepartmentID);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //get manager and president Id for using later
            Guid managerRankID = new RankDAL().GetRankIDByRankName("Manager");
            Guid PresidentRankID = new RankDAL().GetRankIDByRankName("President");

            //binding informations on combobox
            columnGenderId.ItemsSource = new EmployeeInformationDAL().GetNameByCategory("Gender");
            columnRankId.ItemsSource = new RankDAL().ListAll();
            columnDepartmentId.ItemsSource = new DepartmentDAL().ListAll();

            //columnDepartmentManagerName.ItemsSource = new EmployeeDAL().ListDepartmentManagers(LoginerDepartmentID, managerRankID);

            //different content shows to different roles
            if (LoginerRankName == "Staff")
            {
                // show manager name on datagrid, I don't know why it doesn't work
                //columnDepartmentManagerName.ItemsSource = new EmployeeDAL().ListDepartmentManagers(LoginerDepartmentID, managerRankID);
                //show single data
                LoadSingleData();
            }
            else if (LoginerRankName == "Manager")
            {
                //columnDepartmentManagerName.ItemsSource = new EmployeeDAL().ListDepartmentManagers(LoginerDepartmentID, managerRankID);
                //show same departments workmates
                LoadDepartmentData();
            }
            else if (LoginerRankName == "President")
            {
                //columnDepartmentManagerName.ItemsSource = new EmployeeDAL().ListDepartmentManagers(LoginerDepartmentID, PresidentRankID);
                //show all
                LoadData();
            }
        }

        private void miSystem_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?",
               "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Successful Loging out!");
                LoginWindow login = new LoginWindow();
                Close();
                login.Show();
            }
        }

        private void miSystemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee employ = (Employee)datagrid.SelectedItem;
            Guid managerRank = new RankDAL().GetRankIDByRankName("Manager");
            if (employ == null)
            {
                MessageBox.Show("Please Select One Record to Delete.");
                return;
            }
            else if (MessageBox.Show("Are you sure you are going to delete this record?",
                "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (managerRank == employ.RankID)
                {
                    new DepartmentDAL().CleanManagerID(employ.DepartmentID);
                }
                new EmployeeDAL().DeleteByID(employ.ID);
                MessageBox.Show("Successful Deleting! Please refresh to see result!");
                return;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);
        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {

            EmployeeEditWindow editWin = new EmployeeEditWindow();
            
            editWin.EditerDptID = LoginerDepartmentID;
            editWin.IsEdited = false;
            if (LoginerRankName == "Manager")
            {
                editWin.tbDepartment.Visibility = Visibility.Hidden;
                editWin.cmbDepartment.Visibility = Visibility.Hidden;
                editWin.cmbRank.Visibility = Visibility.Hidden;
                editWin.tbRank.Visibility = Visibility.Hidden;
                editWin.EditerRank = 1;
                editWin.ShowDialog();
                if (editWin.DialogResult == true)
                {
                    LoadDepartmentData();
                }
            }
            else if (LoginerRankName == "President")
            {
                editWin.EditerRank = 2;

                editWin.ShowDialog();
                if (editWin.DialogResult == true)
                {
                    LoadData();
                }
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = (Employee)datagrid.SelectedItem;
            if (employee == null)
            {
                MessageBox.Show("Please select one record to edit.");
                return;
            }
            else
            {
                EmployeeEditWindow editWin = new EmployeeEditWindow();
                editWin.SelectedUserName = employee.UserName;
                editWin.IsEdited = true;
                //if (LoginerRankName == "Staff")
                //{
                //    editWin.dpContractEndDate.Visibility = Visibility.Hidden;
                //    editWin.dpContractStartDate.Visibility = Visibility.Hidden;
                //    editWin.cmbDepartment.Visibility = Visibility.Hidden;
                //    editWin.cmbGender.Visibility = Visibility.Hidden;
                //    editWin.cmbRank.Visibility = Visibility.Hidden;
                //    editWin.tbDepartment.Visibility = Visibility.Hidden;
                //    editWin.tbRank.Visibility = Visibility.Hidden;
                //    editWin.txtUserName.Visibility = Visibility.Hidden;
                //    editWin.dpBirthday.Visibility = Visibility.Hidden;
                //    editWin.tbBirthday.Visibility = Visibility.Hidden;
                //    editWin.tbConStart.Visibility = Visibility.Hidden;
                //    editWin.tbConEnd.Visibility = Visibility.Hidden;
                //    editWin.tbGender.Visibility = Visibility.Hidden;
                //    editWin.ShowDialog();
                //    if (editWin.DialogResult == true)
                //    {
                //        LoadSingleData();
                //    }

                //}
                if (LoginerRankName == "Manager")
                {
                    editWin.tbDepartment.Visibility = Visibility.Hidden;
                    editWin.cmbDepartment.Visibility = Visibility.Hidden;
                    editWin.cmbRank.Visibility = Visibility.Hidden;
                    editWin.tbRank.Visibility = Visibility.Hidden;
                    editWin.ShowDialog();
                    if (editWin.DialogResult == true)
                    {
                        LoadDepartmentData();
                    }
                }
                else if (LoginerRankName == "President")
                {
                    editWin.ShowDialog();
                    if (editWin.DialogResult == true)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void miBuidSalarySheet_Click(object sender, RoutedEventArgs e)
        {
            SalarySheet salarysheet = new SalarySheet();
            salarysheet.editerRank = LoginerRankName;
            salarysheet.editerDptID = LoginerDepartmentID;
            salarysheet.ShowDialog();
            
        }

        private void miObjects_Click(object sender, RoutedEventArgs e)
        {
            ProjectsWindow prjWin = new ProjectsWindow();
            prjWin.Show();
        }

    }
}
