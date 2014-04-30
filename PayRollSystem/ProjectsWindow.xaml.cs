using PayRollSystemDAL;
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
            ProjectEditWindow prjEW = new ProjectEditWindow();
            prjEW.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ProjectEditWindow prjEW = new ProjectEditWindow();
            prjEW.Show();
        }

    }
}
