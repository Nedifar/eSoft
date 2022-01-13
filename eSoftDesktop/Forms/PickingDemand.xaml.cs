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
using System.Data.Entity;

namespace eSoftDesktop.Forms
{
    /// <summary>
    /// Логика взаимодействия для PickingDemand.xaml
    /// </summary>
    public partial class PickingDemand : Window
    {
        Models.Supply _supply = new Models.Supply();
        public PickingDemand(Models.Supply supply)
        {
            InitializeComponent();
            _supply = supply;
            List<Models.Demand> demands = new List<Models.Demand>();
            foreach (var dem in Models.context.aGetContext().Demands.Include(p=>p.Deals).Where(p => p.Deals.Count == 0 && p.minPrice <= supply.Price))
            {
                if (dem.maxPrice == 0)
                {
                    demands.Add(dem);
                }
                else if (dem.maxPrice >= supply.Price)
                {
                    demands.Add(dem);
                }
            }
            dgEstates.ItemsSource = demands;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dgEstates.SelectedItems.Count == 0)
            {
                MessageBox.Show("Не дури.");
            }
            else
            {
                Models.Deal deal = new Models.Deal();
                deal.IdSupply = _supply.idSupply;
                deal.IdDemand = (dgEstates.SelectedItem as Models.Demand).idDemand;
                Models.context.aGetContext().Deals.Add(deal);
                Models.context.aGetContext().SaveChanges();
                MessageBox.Show("Сделка успешно заключена.");
                Close();
            }
        }
    }
}
