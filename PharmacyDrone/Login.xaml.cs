using PharmacyDrone.Classes;
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

namespace PharmacyDrone
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Notify notifier = new Notify();
        public Login()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
        public static int accountType;
        public static int userId;
        bool flag = false;
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (txtUsername.Text == String.Empty || txtPassword.Password == String.Empty)
            {
                notifier.error("Fields cannot be empty");
            }
            else
            {
                User u = new User();
                List<User> userList = u.readUsers();


                foreach (User item in userList)
                {
                    if (item.Username == txtUsername.Text && item.Password == txtPassword.Password)
                    {
                        flag = true;
                        switch (item.State)
                        {
                            case 1:
                                {
                                    notifier.warning("Your account is Pending");
                                    break;
                                }
                            case 2:
                                {
                                    accountType = item.AccountType;
                                    userId = item.UserId;

                                    Main m = new Main();
                                    m.Show();
                                    this.Close();


                                    break;
                                }
                            case 3:
                                {
                                    notifier.error("Your account is Suspended");
                                    break;
                                }
                            case 4:
                                {
                                    notifier.error("Your account is Inactive");
                                    break;
                                }
                            default:
                                break;
                        }
                    }

                }

                if (!flag)
                {
                    notifier.error("Username and/or Password is incorrect");
                    txtUsername.Clear();
                    txtPassword.Clear();
                }

            }
        }

        

        private void lblRegister_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            r.Show();
            this.Close();
        }
    }
}
