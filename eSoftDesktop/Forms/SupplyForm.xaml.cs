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
    /// Логика взаимодействия для SupplyForm.xaml
    /// </summary>
    public partial class SupplyForm : Window
    {
        public SupplyForm()
        {
            InitializeComponent();
            dgSupply.ItemsSource = Models.context.aGetContext().Supplies.ToList();
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            AddEditSupplyWindow add = new AddEditSupplyWindow(null);
            add.Show();
            add.IsVisibleChanged += Add_IsVisibleChanged;
        }

        private void Add_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender as Window).Visibility == Visibility.Visible)
            {
                dgSupply.ItemsSource = Models.context.aGetContext().Supplies.ToList();
            }
            else
            { }

        }

        private void clDelete(object sender, RoutedEventArgs e)
        {
            if (dgSupply.SelectedItem != null)
            {
                Models.context.aGetContext().Supplies.Remove(dgSupply.SelectedItem as Models.Supply);
                Models.context.aGetContext().SaveChanges();
                dgSupply.ItemsSource = Models.context.aGetContext().Supplies.ToList();

            }
            else
                MessageBox.Show("Выберите объект для операции!");

        }

        private void clEdit(object sender, RoutedEventArgs e)
        {
            if (dgSupply.SelectedItem != null)
            {
                AddEditSupplyWindow add = new AddEditSupplyWindow(dgSupply.SelectedItem as Models.Supply);
                add.Show();
            }
            else
                MessageBox.Show("Выберите объект для операции!");
        }

        private void clPick(object sender, RoutedEventArgs e)
        {
            if (dgSupply.SelectedItem != null && (dgSupply.SelectedItem as Models.Supply).Deals.Count == 0)
            {
                PickingDemand add = new PickingDemand(dgSupply.SelectedItem as Models.Supply);
                add.Show();
            }
            else
                MessageBox.Show("Выберите объект для операции!");
        }
    }
}
