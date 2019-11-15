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
    /// Interaction logic for SuppliesWindow.xaml
    /// </summary>
    public partial class SuppliesWindow : UserControl
    {
        public List<Types> typeList = new List<Types>();
        Notify notifier = new Notify();
        public SuppliesWindow()
        {
            InitializeComponent();

            //MedicalSupply ms = new MedicalSupply();
            //List<MedicalSupply> supplyList = ms.readMedicalSupplies();
            //dgvSupplies.ItemsSource = supplyList;
            //this.DataContext = supplyList;

            typeList.Add(new Types("Pill"));
            typeList.Add(new Types("Tablet"));
            typeList.Add(new Types("Vaccine"));
            typeList.Add(new Types("Antibiotic"));
            typeList.Add(new Types("Antiviral"));

            cmbType.ItemsSource = typeList;

        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text!=String.Empty || txtDesc.Text != String.Empty || txtPrice.Text != String.Empty)
            {
                int n;
                if (int.TryParse(txtPrice.Text,out n)) //////////////////////////////////////////////////////////////           Testing needed
                {
                    string name = txtName.Text;
                    string desc = txtDesc.Text;
                    int price = int.Parse(txtPrice.Text);
                    int val = cmbType.SelectedIndex;
                    string type = typeList[val].SupplyType;

                    MedicalSupply ms = new MedicalSupply(name, type, desc, price);

                    if (ms.InsertMedicalSupply(ms))
                    {
                        notifier.success("Medical Supply added succesfully");
                    }
                    else
                    {
                        notifier.error("Error adding Medical supply");
                    }
                }
                else
                {
                    notifier.error("Price must be a number");
                }
               
            }
            else
            {
                notifier.error("Fields cannot be empty");
            }
           
            

        }
        public class Types
        {

            private string supplyType;

            
            public string SupplyType { get => supplyType; set => supplyType = value; }

            public Types(string supplyType)
            {
                this.SupplyType = supplyType;
            }
        }
    }
}
