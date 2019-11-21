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
    /// Interaction logic for DispatchWindow.xaml
    /// </summary>
      public class Num
    {
        private int orderNum;

        public int OrderNum { get => orderNum; set => orderNum = value; }

        public Num(int orderNum)
        {
            this.orderNum = orderNum;
        }
        
       
    }
    public partial class DispatchWindow : UserControl
    {
        Notify notifier = new Notify();

        List<Num> refinedOrderNum = new List<Num>();
        List<OrderRequest> orderRequestsList = new List<OrderRequest>();
        private int userId;
        public DispatchWindow()
        {
            InitializeComponent();
            gDispatch.Visibility = Visibility.Hidden;

            OrderRequest or = new OrderRequest();


            orderRequestsList = or.ReadOrderRequests();

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



        public string dispatch = " ";
        int total = 0;
        int order = 0;
        private void CmbOrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gDispatch.Visibility = Visibility.Visible;


            txtDispatch.Clear();
            int index = cmbOrderList.SelectedIndex;
            order = refinedOrderNum[index].OrderNum;
            List<MedicalSupply> medicalSupplyList = new List<MedicalSupply>();
            MedicalSupply ms = new MedicalSupply();

            foreach (OrderRequest item in orderRequestsList)
            {
               
                if (item.OrderNum == order)
                {
                    userId = item.UserID;
                    medicalSupplyList.Add(ms.readMedicalSuppliesByID(item.MedicalSupplyID));
                }
            }

            dispatch = dispatch + " ============================ \n";

            foreach (MedicalSupply item in medicalSupplyList)
            {
                dispatch = dispatch + item.SupplyName + "\t " + item.SupplyPrice;
                dispatch = dispatch + " ============================ \n";
            }
            
            txtDispatch.Text = dispatch;

            foreach (MedicalSupply item in medicalSupplyList)
            {
                total = total + item.SupplyPrice;
            }

            lblTotal.Content = "R" + total;


        }

        private void BtnDispatche_Click(object sender, RoutedEventArgs e)
        {

            OrderRequest or = new OrderRequest();
            if (or.UpdateState(userId,1))
            {
                notifier.success("Order has been dispatched");
            }
            else
            {
                notifier.error("Failed to Dispatch");
            }
            AboutUsWindow main = new AboutUsWindow();
            Content = main;

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Main m = new Main();
            MainWindow mw = new MainWindow();
            m.Cc.Content = mw;
        }
    }
}
