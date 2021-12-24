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
    /// Логика взаимодействия для DemandForm.xaml
    /// </summary>
    public partial class DemandForm : Window
    {
        public DemandForm()
        {
            InitializeComponent();
            dgEstates.ItemsSource = Models.context.aGetContext().Demands.Include(p=>p.Client).Include(p=>p.Realtor).Include(p=>p.ApartamentDemands).Include(p => p.HouseDemands).Include(p => p.LandDemands).ToList();
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            AddEditDemandWindow add = new AddEditDemandWindow(null);
            add.Show();
            add.IsVisibleChanged += Add_IsVisibleChanged;
        }

        private void Add_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender as Window).Visibility == Visibility.Visible)
            {
                dgEstates.ItemsSource = Models.context.aGetContext().Demands.Include(p => p.Client).Include(p => p.Realtor).ToList();
            }
            else
            { }

        }

        private void clDelete(object sender, RoutedEventArgs e)
        {
            if (dgEstates.SelectedItem != null)
            {
                var rem = (dgEstates.SelectedItem as Models.Demand);
                try
                {
                    Models.context.aGetContext().Demands.Remove(rem);
                    Models.context.aGetContext().SaveChanges();
                }
                catch
                {
                    try
                    {

                    }
                    catch
                    {

                    }
                }
                Models.context.aGetContext().SaveChanges();
                dgEstates.ItemsSource = Models.context.aGetContext().Demands.Include(p => p.Client).Include(p => p.Realtor).ToList();

            }
            else
                MessageBox.Show("Выберите объект для операции!");

        }

        private void clEdit(object sender, RoutedEventArgs e)
        {
            if (dgEstates.SelectedItem != null)
            {
                AddEditDemandWindow add = new AddEditDemandWindow(dgEstates.SelectedItem as Models.Demand);
                add.Show();
            }
            else
                MessageBox.Show("Выберите объект для операции!");
        }
    }
}
