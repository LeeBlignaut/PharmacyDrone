﻿using PharmacyDrone.Classes;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        Notify notifier = new Notify();
        public Main()
        {
            InitializeComponent();


        
            int i = Login.accountType;
            int u = Login.userId;
    

            if (i ==0) //If patient
            {
                btnDispatch.IsEnabled = false;
                btnPatients.IsEnabled = false;
                btnSupplies.IsEnabled = false;
               
                MainWindow mw = new MainWindow();
                Cc.Content = mw;
            }
            else if(i==1) //If admin
            {
                btnOrder.IsEnabled = false;
                AboutUsWindow ab = new AboutUsWindow();
                Cc.Content = ab;
            }

         

        }

        private void BtnDispatch_Click(object sender, RoutedEventArgs e)
        {
            DispatchWindow dw = new DispatchWindow();
            Cc.Content = dw;

            
        }

        private void BtnPatients_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow pw = new PatientWindow();
            Cc.Content = pw;
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow ow = new OrderWindow();
            Cc.Content = ow;
        }

        private void BtnSupplies_Click(object sender, RoutedEventArgs e)
        {
            SuppliesWindow sw = new SuppliesWindow();
            Cc.Content = sw;
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
         
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

      
    }
}
