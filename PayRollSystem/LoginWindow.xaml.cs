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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text;
            string pwd = pwdBoxLogin.Password;
            MainWindow mainwin = new MainWindow();
            Employee Loginer = new EmployeeDAL().GetByUerName(username);
            if (Loginer == null)
            {
                MessageBox.Show("UserName or Password is incorrect or you are deleted from system!");
            }
            else
            {
                if (Loginer.Password == pwd)
                {
                    Rank LoginerRank = new RankDAL().GetByID(Loginer.RankID);

                    if (LoginerRank.RankName == "Staff")
                    {
                        MessageBox.Show("Welcome! Dear: " + LoginerRank.RankName + " " + Loginer.RealName + " !");
                        //mainwin.gbSearching.Visibility = Visibility.Hidden;
                        mainwin.tbEdit.IsEnabled = false;
                        mainwin.mnFile.IsEnabled = false;
                        mainwin.LoginerRankName = "Staff";
                        mainwin.LoginerID = Loginer.ID;
                        mainwin.LoginerDepartmentID = Loginer.DepartmentID;
                        mainwin.Show();
                        Close();
                    }
                    if (LoginerRank.RankName == "Manager")
                    {
                        MessageBox.Show("Welcome! Dear: " + LoginerRank.RankName + " " + Loginer.RealName + " !");
                        mainwin.LoginerRankName = "Manager";
                        mainwin.LoginerID = Loginer.ID;
                        mainwin.LoginerDepartmentID = Loginer.DepartmentID;
                        //********************
                        //mainwin.gbSearching.Visibility = Visibility.Hidden;
                        //********************
                        mainwin.Show();
                        Close();
                    }
                    if (LoginerRank.RankName == "President")
                    {
                        MessageBox.Show("Welcome! Dear: " + LoginerRank.RankName + " " + Loginer.RealName + " !");
                        mainwin.LoginerRankName = "President";
                        mainwin.LoginerID = Loginer.ID;
                        mainwin.LoginerDepartmentID = Loginer.DepartmentID;
                        //*********************
                        //mainwin.gbSearching.Visibility = Visibility.Hidden;
                        //*********************
                        mainwin.Show();
                        Close();
                    }
                }
                else 
                {
                    MessageBox.Show("UserName or Password is incorrect !");
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Good Bye!");
            Application.Current.Shutdown();
        }
    }
}
