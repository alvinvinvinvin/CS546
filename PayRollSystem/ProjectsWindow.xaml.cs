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
    /// Interaction logic for ProjectsWindow.xaml
    /// </summary>
    public partial class ProjectsWindow : Window
    {
        public Guid dptID;
        public ProjectsWindow()
        {
            InitializeComponent();
        }

        public void loadAllData()
        {
            datagrid.ItemsSource = new ProjectDAL().listAll();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadAllData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Department editorDpt = new DepartmentDAL().getByID(dptID);
            string admin = editorDpt.DepartmentName;
            if (admin == "PresidentOffice")
            {
                ProjectEditAdmin prjEA = new ProjectEditAdmin();
                prjEA.isEdited = false;
                prjEA.Show();
            }
            else
            {
                ProjectEditWindow prjEW = new ProjectEditWindow();
                prjEW.dpt = editorDpt;
                prjEW.Show();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Project prj = (Project)datagrid.SelectedItem;
            if (prj == null)
            {
                MessageBox.Show("please select project!");
                return;
            }
            Department editorDpt = new DepartmentDAL().getByID(dptID);
            string admin = editorDpt.DepartmentName;
            if (admin == "PresidentOffice")
            {
                ProjectEditAdmin prjEA = new ProjectEditAdmin();
                prjEA.isEdited = true;
                prjEA.prj = prj;
                prjEA.Show();
            }
            else
            {
                ProjectEditWindow prjEW = new ProjectEditWindow();
                prjEW.prj = prj;
                prjEW.Show();
            }
        }

    }
}
