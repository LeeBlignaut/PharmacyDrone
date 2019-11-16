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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        Notify notifier = new Notify();
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Equals(txtConfirmPassword.Password))
            {
                User u = new User(txtUsername.Text, txtPassword.Password, 0, 1);

                if (u.insertUser(u))
                {
                    notifier.success("Account created Succesfully");
                    System.Threading.Thread.Sleep(500);
                    notifier.information("The Admin will activate your account shortly");
                    System.Threading.Thread.Sleep(500);


                    Login l = new Login();
                    l.Show();

                    txtConfirmPassword.Clear();
                    txtPassword.Clear();
                    txtUsername.Clear();
                    this.Hide();

                }
                else
                {
                    notifier.error("Error creating your account");
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
            }
            else
            {
                notifier.error("Passwords don't match");
            }
            
            
        }

       

       
    }
}
