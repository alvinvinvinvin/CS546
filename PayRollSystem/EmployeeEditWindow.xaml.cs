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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PayRollSystem
{
    /// <summary>
    /// Interaction logic for EmployeeEditWindow.xaml
    /// </summary>
    public partial class EmployeeEditWindow : Window
    {
        public bool IsEdited { get; set; }
        public int EditerRank { get; set; }
        public Guid EditerDptID { get; set; }
        public Guid EmployeeIDBeingEdited { get; set; }
        public string SelectedUserName { get; set; }
        public EmployeeEditWindow()
        {
            InitializeComponent();
        }
        private void CheckTextBoxNotEmpty(ref bool isValid,
                                params TextBox[] textboxes)
        {
            foreach (TextBox txtbox in textboxes)
            {
                if (txtbox.Text.Length <= 0)
                {
                    isValid = false;
                    txtbox.Background = Brushes.Red;
                }
                else
                {
                    txtbox.Background = null;
                }
            }
        }
        private void CheckComBoNotEmpty(ref bool isValid,
                                params ComboBox[] comboboxes)
        {
            foreach (ComboBox cbbox in comboboxes)
            {
                if (cbbox.SelectedIndex < 0)
                {
                    isValid = false;
                    cbbox.Effect = new DropShadowEffect { Color = Colors.Red };
                }
                else
                {
                    cbbox.Effect = null;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeInformationDAL EmpInforDAL = new EmployeeInformationDAL();
            RankDAL rankDAL = new RankDAL();
            DepartmentDAL departDAL = new DepartmentDAL();

            cmbGender.ItemsSource = EmpInforDAL.GetNameByCategory("Gender");
            cmbRank.ItemsSource = rankDAL.ListAll();
            cmbDepartment.ItemsSource = departDAL.ListAll();

            Employee employee = new Employee();
            employee.Birthday = DateTime.Today;
            employee.ContractStartDate = DateTime.Today;
            employee.ContractEndDate = DateTime.Today.AddYears(1);
            employee.RankID = rankDAL.GetRankIDByRankName("Staff");
            //employee.Password = pwdPassword.Password;
            employee.DepartmentID = EditerDptID;
            employee.PaidFreq = txtPaidFreq.Text;

            if (IsEdited == false)
            {
                
                gridEdit.DataContext = employee;

            }
            else
            {
                Employee newemployee = new EmployeeDAL().GetByUerName(SelectedUserName);
                gridEdit.DataContext = newemployee;
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            CheckTextBoxNotEmpty(ref isValid, txtUserName, txtRealName);
            CheckComBoNotEmpty(ref isValid, cmbDepartment,cmbGender,cmbRank);
            if (pwdPassword.Password.Length <= 0)
            {
                isValid = false;
                pwdPassword.Background = Brushes.Red;
            }
            else 
            {
                pwdPassword.Background = null;
            }
            if (isValid == false)
            {
                return;
            }
            if (IsEdited == false)
            {
                Employee employee = new Employee();
                employee = (Employee)gridEdit.DataContext;
                EmployeeDAL empDAL = new EmployeeDAL();
                DepartmentDAL dptDAL = new DepartmentDAL();
                if (empDAL.CheckExsited(employee.UserName))
                {
                    MessageBox.Show("UserName is already exsited");
                    return;
                }
                else
                {
                    if (empDAL.CheckManagerExisted(employee))
                    {
                        MessageBox.Show("Manager is already exsited, please demote existed manager first!");
                        return;
                    }
                    else
                    {
                        employee.Password = pwdPassword.Password;
                        EmployeeDAL dal = new EmployeeDAL();
                        dal.Insert(employee);
                        dal.UpdateManagerIDtoDepartmentTable(employee);
                        dal.UpLoadManagerName(employee);
                    }
                }
            }
            else
            {
                Employee employee = (Employee)gridEdit.DataContext;
                if (new EmployeeDAL().CheckManagerExisted(employee))
                {
                    MessageBox.Show("Manager is already exsited, please demote existed manager first!");
                    return;
                }
                else if(new EmployeeDAL().CheckExsited(employee.UserName))
                {
                    MessageBox.Show("UserName is already exsited");
                    return;
                }
                else
                {
                    new EmployeeDAL().Update(employee);
                }
            }
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
