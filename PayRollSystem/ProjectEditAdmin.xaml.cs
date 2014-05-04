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
    /// Interaction logic for ProjectEditAdmin.xaml
    /// </summary>
    public partial class ProjectEditAdmin : Window
    {
        public Project prj;
        public bool isEdited;
        public ProjectEditAdmin()
        {
            InitializeComponent();
        }
        public void ListAllDepartment()
        {
            datagrid.ItemsSource = new DepartmentDAL().ListAll();
        }
        public void ListAssignedDepartment()
        {
            //5/4 1:00 AM
            datagrid.ItemsSource = new ProjectDAL().listAssignedDepartment(prj);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProjectDAL prjDAL = new ProjectDAL();
            if (isEdited)
            {
                ListAssignedDepartment();
                txtPeriod.Text = prjDAL.countPeriod(prj).ToString();
                gridPrj.DataContext = prj;
            }
            else
            {
                ListAllDepartment();
            }
            
        }
    }
}
