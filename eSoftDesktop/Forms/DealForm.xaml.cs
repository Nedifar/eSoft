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
    /// Логика взаимодействия для DealForm.xaml
    /// </summary>
    public partial class DealForm : Window
    {
        public DealForm()
        {
            InitializeComponent();
            dgDeal.ItemsSource = Models.context.aGetContext().Deals.ToList();
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            AddEditDealWindow addEditDealWindow = new AddEditDealWindow(null);
            addEditDealWindow.Show();
            addEditDealWindow.IsVisibleChanged += AddEditDealWindow_IsVisibleChanged;
        }

        private void AddEditDealWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if((sender as Window).Visibility == Visibility.Visible)
            {
                dgDeal.ItemsSource = Models.context.aGetContext().Deals.ToList();
            }
        }

        private void clDelete(object sender, RoutedEventArgs e)
        {
            if (dgDeal.SelectedItems.Count == 0)
                MessageBox.Show("Ты конченный");
            else
            {
                Models.context.aGetContext().Deals.Remove(dgDeal.SelectedItem as Models.Deal);
                Models.context.aGetContext().SaveChanges();
                dgDeal.ItemsSource = Models.context.aGetContext().Deals.ToList();

            }
        }

        private void clEdit(object sender, RoutedEventArgs e)
        {
            if (dgDeal.SelectedItems.Count == 0)
                MessageBox.Show("Ты конченный");
            else
            {
                AddEditDealWindow addEditDealWindow = new AddEditDealWindow((dgDeal.SelectedItem as Models.Deal));
                addEditDealWindow.Show();
                addEditDealWindow.IsVisibleChanged += AddEditDealWindow_IsVisibleChanged;
            }
        }
    }
}
