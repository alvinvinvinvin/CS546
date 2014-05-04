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
            datagrid.ItemsSource = new ProjectDAL().listAllParticipators(prj);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            colRankId.ItemsSource = new RankDAL().ListAll();

        }

    }
}
