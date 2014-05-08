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
        public void loadAssigned()
        {

            datagrid.ItemsSource = new ProjectDAL().listPrjsByDpt(dptID);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Department editorDpt = new DepartmentDAL().getByID(dptID);
            string admin = editorDpt.DepartmentName;
            if (admin == "PresidentOffice")
            {
                loadAllData();
            }
            else
            {
                loadAssigned();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Department editorDpt = new DepartmentDAL().getByID(dptID);
            string admin = editorDpt.DepartmentName;
            if (admin == "PresidentOffice")
            {
                ProjectEditAdmin prjEA = new ProjectEditAdmin();
                prjEA.isEdited = false;
                //prjEA.btnDelete.Visibility = Visibility.Hidden;
                prjEA.ShowDialog();
                if (prjEA.DialogResult == true)
                    loadAllData();
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
                //prjEA.btnDelete.Visibility = Visibility.Hidden;
                prjEA.prj = prj;
                prjEA.ShowDialog();
                if (prjEA.DialogResult == true)
                    loadAllData();
            }
            else
            {
                ProjectEditWindow prjEW = new ProjectEditWindow();
                prjEW.prj = prj;
                prjEW.dpt = editorDpt;
                prjEW.ShowDialog();
                if (prjEW.DialogResult == true)
                    loadAssigned();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Department editorDpt = new DepartmentDAL().getByID(dptID);
            string admin = editorDpt.DepartmentName;
            if (admin == "PresidentOffice")
            {
                Project prj = (Project)datagrid.SelectedItem;
                if (prj == null)
                {
                    MessageBox.Show("please select project to delete!");
                    return;
                }
                else
                {
                    ProjectDAL prjDAL = new ProjectDAL();
                    prjDAL.deletePrj(prj);
                    MessageBox.Show("Successful deleting!");
                }
                loadAllData();
            }
            
        }

    }
}
