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
using System.Device.Location;
using System.Threading;

namespace PharmacyDrone
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : UserControl
    {
        Notify notifier = new Notify();
        GeoCoordinate currentLoc = new GeoCoordinate();
        Drone drone = new Drone();
        public OrderWindow()
        {
            InitializeComponent();
            MedicalSupply ms = new MedicalSupply();
            List<MedicalSupply> medicalSupplyList = ms.readMedicalSupplies();
            cmbMedicineList.ItemsSource = medicalSupplyList;
            this.DataContext = medicalSupplyList;

            lblBindedID.Visibility = Visibility.Hidden;
            lblBindedName.Visibility = Visibility.Hidden;
            lblBindedPrice.Visibility = Visibility.Hidden;
            lblBindedType.Visibility = Visibility.Hidden;

            lblName.Visibility = Visibility.Hidden;
            lblPrice.Visibility = Visibility.Hidden;
            lblType.Visibility = Visibility.Hidden;
            lblDescription.Visibility = Visibility.Hidden;
            txtNotes.Visibility = Visibility.Hidden;
            btnAdd.Visibility = Visibility.Hidden;
            gCart.Visibility = Visibility.Hidden;

            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
            Thread.Sleep(1000);
            currentLoc = watcher.Position.Location;
            watcher.Stop();

            drone.GetDrone();

            lblLocation.Content = currentLoc.ToString();
            lblDrone.Content = drone.ToString();

            
        
        }

        private void CmbMedicineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblBindedName.Visibility = Visibility.Visible;
            lblBindedPrice.Visibility = Visibility.Visible;
            lblBindedType.Visibility = Visibility.Visible;
            lblName.Visibility = Visibility.Visible;
            lblPrice.Visibility = Visibility.Visible;
            lblType.Visibility = Visibility.Visible;
            lblDescription.Visibility = Visibility.Visible;
            txtNotes.Visibility = Visibility.Visible;
            btnAdd.Visibility = Visibility.Visible;
        }
        List<MedicalSupply> cartList = new List<MedicalSupply>();
        string cart = "   ";
        int total = 0;
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
         
            notifier.success("Added To Cart");
            gCart.Visibility = Visibility.Visible;

            cartList.Add(new MedicalSupply(Convert.ToInt32(lblBindedID.Content.ToString()), lblBindedName.Content.ToString(), lblBindedType.Content.ToString(), txtNotes.Text, Convert.ToInt32(lblBindedPrice.Content.ToString())));
            cart = cart + " ============================ \n";
            cart = cart + lblBindedName.Content.ToString() + "\t " + lblBindedPrice.Content.ToString();
            txtCart.Text = cart;

            foreach (MedicalSupply item in cartList)
            {
                total = total + item.SupplyPrice;
            }

            lblTotal.Content = "R" + total;
        }

       

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderRequest or = new OrderRequest();
            int num = or.GenerateNum();
            bool flag = false;

            foreach (MedicalSupply item in cartList)
            {
                or = new OrderRequest(num, item.SupplyId,Login.userId);
                or.SetDrone(drone.DroneID);
                or.SetGeoLocaton(currentLoc);
                flag = or.InsertOrderRequests(or);

                if (!flag)
                {
                    notifier.error("Error Placing Order");
                }
                

            }

            if (flag)
            {
                notifier.success("Order Placed Succesfully");
                cartList.Clear();
                txtCart.Clear();
                lblTotal.Content = "";
            }
        }

    }
}
