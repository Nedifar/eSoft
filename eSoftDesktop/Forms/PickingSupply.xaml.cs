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
    /// Логика взаимодействия для PickingSupply.xaml
    /// </summary>
    public partial class PickingSupply : Window
    {
        Models.Demand _demand = new Models.Demand();
        public PickingSupply(Models.Demand demand)
        {
            InitializeComponent();
            _demand = demand;
            List<Models.Supply> supplies = new List<Models.Supply>();
            foreach(var sup in Models.context.aGetContext().Supplies.Include(p=>p.Deals).Where(p => p.Deals.Count == 0 && p.Price >= demand.minPrice))
            {
                if(demand.maxPrice ==0)
                {
                    supplies.Add(sup);
                }
                else if(demand.maxPrice >=sup.Price)
                {
                    supplies.Add(sup);
                }
            }
            dgSupply.ItemsSource = supplies;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(dgSupply.SelectedItems.Count == 0)
            {
                MessageBox.Show("Не дури.");
            }
            else
            {
                Models.Deal deal = new Models.Deal();
                deal.IdDemand = _demand.idDemand;
                deal.IdSupply = (dgSupply.SelectedItem as Models.Supply).idSupply;
                Models.context.aGetContext().Deals.Add(deal);
                Models.context.aGetContext().SaveChanges();
                MessageBox.Show("Сделка успешно заключена.");
                Close();
            }
        }
    }
}
