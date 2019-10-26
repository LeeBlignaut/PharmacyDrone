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
        public SuppliesWindow()
        {
            InitializeComponent();

            MedicalSupply ms = new MedicalSupply();
            List<MedicalSupply> supplyList = ms.readMedicalSupplies();
            dgvSupplies.ItemsSource = supplyList;
            this.DataContext = supplyList;

        }

        private void DgvSupplies_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
