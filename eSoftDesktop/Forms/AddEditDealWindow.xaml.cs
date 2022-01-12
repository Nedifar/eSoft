using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace eSoftDesktop.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddEditDealWindow.xaml
    /// </summary>
    public partial class AddEditDealWindow : Window
    {
        private Models.Deal _deal = new Models.Deal();
        public AddEditDealWindow(Models.Deal deal)
        {
            InitializeComponent();
            if (deal != null)
                _deal = deal;
            cbDemand.ItemsSource = Models.context.aGetContext().Demands.Where(p => p.Deals.Count == 0 || p.Deals.FirstOrDefault().IdDemand == _deal.IdDemand).ToList();
            cbSupply.ItemsSource = Models.context.aGetContext().Supplies.Include(p=>p.Realtor).Include(p=>p.MainAHL).Include(p => p.MainAHL.Houses).Include(p => p.MainAHL.Lands).Include(p => p.MainAHL.Apartaments).Where(p => p.Deals.Count == 0 || p.Deals.FirstOrDefault().IdSupply == _deal.IdSupply).ToList();
            DataContext = _deal;
        }

        private void clSAve(object sender, RoutedEventArgs e)
        {
            if (_deal.IdDeal == 0)
                Models.context.aGetContext().Deals.Add(_deal);
            Models.context.aGetContext().SaveChanges();
        }

        private void cbSupply_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double price = Convert.ToDouble(((sender as ComboBox).SelectedItem as Models.Supply).Price);
            if (((sender as ComboBox).SelectedItem as Models.Supply).MainAHL.Apartaments.Count != 0)
            {
                tbOtSeller.Text = (36000 + price / 100).ToString();
            }
            else if (((sender as ComboBox).SelectedItem as Models.Supply).MainAHL.Lands.Count != 0)
            {
                tbOtSeller.Text = (30000 + price / 100 *2).ToString();
            }
            else if (((sender as ComboBox).SelectedItem as Models.Supply).MainAHL.Houses.Count != 0)
            {
                tbOtSeller.Text = (30000 + price / 100).ToString();
            }
            tbOtBuyer.Text = (price / 100*3).ToString();
            tbOtRiel.Text = (Convert.ToDouble(((sender as ComboBox).SelectedItem as Models.Supply).Realtor.comissionPart) /100 * Convert.ToDouble(tbOtBuyer.Text)).ToString();
        }
    }
}
