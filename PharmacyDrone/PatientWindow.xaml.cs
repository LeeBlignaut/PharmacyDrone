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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PharmacyDrone
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : UserControl
    {
        public List<States> stateList = new List<States>();
        Notify notifier = new Notify();
        public PatientWindow()
        {
            InitializeComponent();

            stateList.Add(new States("Pending"));
            stateList.Add(new States("Active"));
            stateList.Add(new States("Suspended"));
            stateList.Add(new States("Inactive"));

            User u = new User();
            List<User> userList = u.readUsers();
            List<User> newUserList = new List<User>();
            foreach (User item in userList)
            {
                //if (item.AccountType == 0)
              //  {
                   item.Password = "*****";
                   newUserList.Add(item);
              //  }
               
            }
            dgvUsers.ItemsSource = newUserList;
            gView.Visibility = Visibility.Hidden;
            cmbStates.ItemsSource = stateList;
            this.DataContext = stateList;
        }
        
        private void DgvUsers_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            gView.Visibility = Visibility.Visible;

            if (lblAc.Content.ToString() == "0")
            {
                lblAccountType.Content = "Patient";
                cmbStates.IsEnabled = true;
            }
            else
            {
                lblAccountType.Content = "Admin";
                cmbStates.IsEnabled = false;
            }
            switch (Convert.ToInt32(lblAcs.Content.ToString()))
            {
                case 1:
                    {
                        lblAccountState.Content = "Pending";
                        break;
                    }
                case 2:
                    {
                        lblAccountState.Content = "Active";
                        break;
                    }
                case 3:
                    {
                        lblAccountState.Content = "Suspended";
                        break;
                    }
                case 4:
                    {
                        lblAccountState.Content = "Inactive";
                        break;
                    }
                default:
                    break;
            }
        }

        int check;
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            int i = cmbStates.SelectedIndex + 1;


            if (Convert.ToInt32(lblAcs.Content.ToString()) == i)
            {
                notifier.error("Account is already in that state");
            }
            else
            {
                
                //checkbox
                //lblac
                User u = new User();
                u.updateState(i, Convert.ToInt32(lblu.Content.ToString()),check);
                notifier.success("Account Updated Succesfully");

                AboutUsWindow main = new AboutUsWindow();
                Content = main;
            }

        }

        private void cbAdmin_Checked(object sender, RoutedEventArgs e)
        {
            
            if(check == 0)
            {
                cmbStates.IsEnabled = false;
                check = 1;
            }
            else
            {
                cmbStates.IsEnabled = true;
                check = 0;
            }
            
        }

    }

    public class States
    {
        private string state;

        public string State { get => state; set => state = value; }

        public States(string state)
        {
            this.state = state;
          
        }
    }
}
