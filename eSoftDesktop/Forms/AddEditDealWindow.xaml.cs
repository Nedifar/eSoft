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

namespace eSoftDesktop.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddEditDealWindow.xaml
    /// </summary>
    public partial class AddEditDealWindow : Window
    {
        private Models.Deal deal = new Models.Deal();
        public AddEditDealWindow(Models.Deal _deal)
        {
            InitializeComponent();
            if (_deal != null)
                deal = _deal;
            DataContext = deal;
            cbSup.ItemsSource = Models.context.aGetContext().Supplies.Where(p => p.idClient == null).ToList();
            cbdem.ItemsSource = Models.context.aGetContext().Demands.Where(p => p.idRealtor == null).ToList();
        }

        private void clSAve(object sender, RoutedEventArgs e)
        {
            if (cbdem.SelectedIndex == -1 || cbSup.SelectedIndex == -1)
            {
                MessageBox.Show("Error");
            }
            else
            {
                if (deal.idDeal == 0)
                {
                    Models.context.aGetContext().Deals.Add(deal);
                }
                Models.context.aGetContext().SaveChanges();
                MessageBox.Show("Saved");
                Close();
            }
        }
    }
}
