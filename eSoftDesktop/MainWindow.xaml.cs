using System;
using System.Collections.Generic;
using System.IO;
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

namespace eSoftDesktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gg();
        }

        private void clRieltor(object sender, RoutedEventArgs e)
        {
            Forms.RealtorForm realtorForm = new Forms.RealtorForm();
            realtorForm.Show();
        }

        private void clClient(object sender, RoutedEventArgs e)
        {
            Forms.ClientForm client = new Forms.ClientForm();
            client.Show();
        }

        private void gg()
        {
            var stream = File.ReadAllLines(@"C:\Users\gazimov.ii0794\Desktop\supplies.txt");

            foreach (var line in stream)
            {
                var kk = new Models.Supply();
                string[] massiv = line.Split('\t');
                kk.clientId = int.Parse(massiv[0]);
                kk.realtorId = int.Parse(massiv[1]);
                kk.homeId = int.Parse(massiv[2]);
                kk.Price = int.Parse(massiv[3]);
                Models.contetx.aGetContext().Supplies.Add(kk);
                Models.contetx.aGetContext().SaveChanges();
            }
        }

        private void clEstate(object sender, RoutedEventArgs e)
        {
            Forms.EstateForm estate = new Forms.EstateForm();
            estate.Show();
        }

        private void clSupply(object sender, RoutedEventArgs e)
        {
            Forms.SupplyForm supply = new Forms.SupplyForm();
            supply.Show();
        }
    }
}
