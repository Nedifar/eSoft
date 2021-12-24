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
    /// Логика взаимодействия для DeakForm.xaml
    /// </summary>
    public partial class DeakForm : Window
    {
        public DeakForm()
        {
            InitializeComponent();
            dgDeals.ItemsSource = Models.context.aGetContext().Deals.Include(p => p.Demand).Include(p => p.Supply).ToList();
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            AddEditDealWindow add = new AddEditDealWindow(null);
            add.Show();
            add.IsVisibleChanged += Add_IsVisibleChanged;
        }

        private void Add_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender as Window).Visibility == Visibility.Visible)
            {
                dgDeals.ItemsSource = Models.context.aGetContext().Deals.ToList();
            }
            else
            { }

        }

        private void clDelete(object sender, RoutedEventArgs e)
        {
            if (dgDeals.SelectedItem != null)
            {
                Models.context.aGetContext().Deals.Remove(dgDeals.SelectedItem as Models.Deal);
                Models.context.aGetContext().SaveChanges();
                dgDeals.ItemsSource = Models.context.aGetContext().Clients.ToList();

            }
            else
                MessageBox.Show("Выберите объект для операции!");

        }

        private void clEdit(object sender, RoutedEventArgs e)
        {
            if (dgDeals.SelectedItem != null)
            {
                AddEditDealWindow add = new AddEditDealWindow(dgDeals.SelectedItem as Models.Deal);
                add.Show();
            }
            else
                MessageBox.Show("Выберите объект для операции!");
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
