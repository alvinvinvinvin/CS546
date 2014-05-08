using PayRollSystemDAL;
using PayRollSystemModel;
using System;
using System.Collections;
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
        public List<Department> dptsToInsert = new List<Department>();
        public ProjectEditAdmin()
        {
            InitializeComponent();
        }
        public void ListAllDpt()
        {
            datagrid.ItemsSource = new DepartmentDAL().ListAll();
        }
        public void ListAllAssignedDepartment()
        {
            Department[] allDpts = new DepartmentDAL().ListAll();
            ProjectDAL prjDAL = new ProjectDAL();
            for (int i = 0; i < allDpts.Length; i++)
            {
                if (prjDAL.IsAssignedDptExisted(prj, allDpts[i]))
                {
                    allDpts[i].IsSelected = true;
                }
                else allDpts[i].IsSelected = false;
            }
            datagrid.ItemsSource = allDpts;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProjectDAL prjDAL = new ProjectDAL();
            Project prjNew = new Project();
            //editing project by admin
            if (isEdited)
            {
                //if some departments are already assigned, the checkboxes are gonna be checked
                ListAllAssignedDepartment();
                //figuring out period then show it in txtPeriod.
                txtPeriod.Text = prjDAL.countPeriod(prj).ToString();
                
                //binding selected prj to grid
                gridPrj.DataContext = prj;
            }
            else
            {
                ListAllDpt();
                //binding a new prj to grid
                gridPrj.DataContext = prjNew;
            }
            
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Editing
            if (isEdited)
            {
                Department[] dptsCheck = (Department[])datagrid.ItemsSource;
                Project prjToInsert = (Project)gridPrj.DataContext;
                ProjectDAL prjDAL = new ProjectDAL();
                for (int i = 0; i < dptsCheck.Length; i++)
                {
                    if (dptsCheck[i].IsSelected == true)
                    {
                        if (prjDAL.IsAssignedDptExisted(prjToInsert, dptsCheck[i]))
                        {
                            continue;
                        }
                        else
                        {
                            dptsToInsert.Add(dptsCheck[i]);
                        }
                    }
                }
                if (dptsToInsert.Count > 0)
                {
                    prjDAL.insertAssignedDepartment(prjToInsert, dptsToInsert.ToArray());
                    MessageBox.Show("Successful Assigning Chosen Departments.");

                }
                prjToInsert.period = prjDAL.countPeriod(prjToInsert);
                prjToInsert.costinwage = prjDAL.costInWage(prjToInsert) * prjToInsert.period;
                prjDAL.updatePrj(prjToInsert);
                
            }

                //add a new project
            else
            {
                //initializing a new prj to insert into DB
                Project prjToInsert = new Project();
                //binding conteints from gridPrj to this prj.
                prjToInsert = (Project)gridPrj.DataContext;
                ProjectDAL prjDAL = new ProjectDAL();
                //Implementing a guid
                prjToInsert.projectID = System.Guid.NewGuid();
                //check prjName
                if (prjDAL.IsPrjNameExisted(txtProjectName.Text))
                {
                    MessageBox.Show("Project name is already existed, please try again.");
                    return;
                }
                //first time to insert to get newid(), startDate and DueDate required.
                prjDAL.insertPrj(prjToInsert);
                
                //update rest information
                //search it back by name for counting some property.

                //Project prjToUpdate = prjDAL.getPrjbyID(prjToInsert.projectID);
                
                //counting costinwage

                //prjToUpdate.costinwage = prjDAL.costInWage(prjToInsert) * prjDAL.countPeriod(prjToInsert);

                //insert it again

                //prjDAL.updatePrj(prjToUpdate);
                
                //insert relation between dpts and this prj.
                Department[] dptsCheck = (Department[])datagrid.ItemsSource;
                for (int i = 0; i < dptsCheck.Length; i++)
                {
                    if (dptsCheck[i].IsSelected == true)
                    {
                        dptsToInsert.Add(dptsCheck[i]);
                    }
                }
                if (dptsToInsert.Count > 0)
                {
                    prjDAL.insertAssignedDepartment(prjToInsert, dptsToInsert.ToArray());
                    MessageBox.Show("Successful Assigning Chosen Departments.");

                }
                else
                {
                    MessageBox.Show("Please select Departments.");
                    return;

                }
                
                MessageBox.Show("Successful inserting!");
            }
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
