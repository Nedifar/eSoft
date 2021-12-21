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
            //gg();
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
            var stream = File.ReadAllLines(@"C:\Users\gazimov.ii0794\Desktop\agents.txt");

            foreach (var line in stream)
            {
                var kk = new Models.Land();
                string[] massiv = line.Split('\t');
                kk.Id = int.Parse(massiv[0]);
                kk.adressCity = massiv[1];
                kk.adressStreet = massiv[2];
                kk.addressHouse = massiv[3];
                kk.addressNumber = massiv[4];
                kk.coordinateLatitude = massiv[5];
                kk.coordinateLongitude = massiv[6];
                kk.totalArea = double.Parse(massiv[7]);
                Models.contetx.aGetContext().Lands.Add(kk);
                Models.contetx.aGetContext().SaveChanges();
            }
        }

        private void clEstate(object sender, RoutedEventArgs e)
        {
            Forms.EstateForm estate = new Forms.EstateForm();
            estate.Show();
        }
    }
}
