using PharmacyDrone.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToastNotifications;

namespace PharmacyDrone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   
    public partial class MainWindow : UserControl
    {
        List<Num> refinedOrderNum = new List<Num>();
        List<OrderRequest> orderRequestsList = new List<OrderRequest>();
        bool orderdelievered = false;
        Notify notify = new Notify();
        public MainWindow()
        {
           
            InitializeComponent();
            //System.Threading.Thread.Sleep(1000);
            orderdelievered = (new OrderRequest()).UpdateState(Login.userId, 2);
            gOrderInfo.Visibility = Visibility.Hidden;

            OrderRequest or = new OrderRequest();

            
            



            orderRequestsList = or.ReadRecentOrders(Login.userId);

            List<int> orderList = new List<int>();

            foreach (OrderRequest item in orderRequestsList)
            {
               

                if (orderList.Contains(item.OrderNum))
                {

                }
                else
                {
                    orderList.Add(item.OrderNum);
                    refinedOrderNum.Add(new Num(item.OrderNum));
                }
            }


            cmbOrderList.ItemsSource = refinedOrderNum;
            this.DataContext = refinedOrderNum;
            



        }
        public string orderInfo = " ";
        int order = 0;
        int total = 0;
        private void cmbOrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GeoCoordinate loc;
            
            if (orderdelievered)
            {
                GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
                watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
                Thread.Sleep(1000);
                loc = watcher.Position.Location;

                notify.success("you order has now been delievered to : " + loc.ToString());
            }

            gOrderInfo.Visibility = Visibility.Visible;
            orderInfo = " ";
            txtOrderInfo.Text = orderInfo;
            int index = cmbOrderList.SelectedIndex;
            order = refinedOrderNum[index].OrderNum;
            List<MedicalSupply> medicalSupplyList = new List<MedicalSupply>();
            MedicalSupply ms = new MedicalSupply();

            foreach (OrderRequest item in orderRequestsList)
            {

                if (item.OrderNum == order)
                {
                   
                    medicalSupplyList.Add(ms.readMedicalSuppliesByID(item.MedicalSupplyID));
                }
            }

            orderInfo = orderInfo + " ============================ \n";

            foreach (MedicalSupply item in medicalSupplyList)
            {
                orderInfo = orderInfo + item.SupplyName + "\t " + item.SupplyPrice;
                orderInfo = orderInfo + " ============================ \n";
            }

            foreach (MedicalSupply item in medicalSupplyList)
            {
                total = total + item.SupplyPrice;
            }
            orderInfo = orderInfo + "Total : " + total + "\n";
            txtOrderInfo.Text = orderInfo;
            int status = 0;
            foreach (OrderRequest item in orderRequestsList)
            {
                if (item.OrderNum == refinedOrderNum[index].OrderNum)
                {
                    status = item.OrderStatus;
                }
            }

            switch (status)
            {
                case 0:
                    
                        lblStatus.Content = "Pending";
                        
                    
                    break;
                case 1:
                    
                        lblStatus.Content = "In Progress";
                    
                    break;
                case 2:
                    
                        lblStatus.Content = "Completed";
                    
                    break;
                default:
                    lblStatus.Content = "Error";
                    break;
            }

            

        }
    }
}
