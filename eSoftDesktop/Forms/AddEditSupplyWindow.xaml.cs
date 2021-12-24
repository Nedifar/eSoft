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
    /// Логика взаимодействия для AddEditSupplyWindow.xaml
    /// </summary>
    public partial class AddEditSupplyWindow : Window
    {
        private Models.Supply supply = new Models.Supply();
        public AddEditSupplyWindow(Models.Supply _supply)
        {
            InitializeComponent();
            if (_supply != null)
                supply = _supply;
            cbClients.ItemsSource = Models.context.aGetContext().Clients.ToList();
            cbRealtors.ItemsSource = Models.context.aGetContext().Realtors.ToList();
            cbHomes.ItemsSource = Models.context.aGetContext().MainAHLs.ToList();
            DataContext = supply;
        }

        private void clSAve(object sender, RoutedEventArgs e)
        {
            //int i = (cbHomes.SelectedItem as Models.OutputHouse).Id;
            //supply.MainAHL = Models.context.aGetContext().MainAHLs.Where(p => p.idAHL == i).FirstOrDefault();
            if (cbClients.SelectedIndex == -1 || cbHomes.SelectedIndex == -1 || cbRealtors.SelectedIndex == -1)
            {
                MessageBox.Show("Error");
            }
            else
            {
                if (supply.idSupply == 0)
                {
                    Models.context.aGetContext().Supplies.Add(supply);
                }
                Models.context.aGetContext().SaveChanges();
                MessageBox.Show("Saved");
                Close();
            }
        }
        public List<Models.OutputHouse> getListForDG()
        {
            List<Models.OutputHouse> output = new List<Models.OutputHouse>();
            foreach (var line in Models.context.aGetContext().Apartaments.Include(p=>p.MainAHL))
            {
                var res = new Models.OutputHouse { addressHouse = line.MainAHL.addressHouse, addressNumber = line.MainAHL.addressNumber, adressCity = line.MainAHL.adressCity, adressStreet = line.MainAHL.adressStreet, coordinateLatitude = line.MainAHL.coordinateLatitude, coordinateLongitude = line.MainAHL.coordinateLongitude, Floor = line.Floor, Id = line.idAHL, Rooms = line.Rooms, totalArea = line.MainAHL.totalArea, Type = "Апарматенты" };
                output.Add(res);
            }
            foreach (var line in Models.context.aGetContext().Houses.Include(p => p.MainAHL))
            {
                var res = new Models.OutputHouse { addressHouse = line.MainAHL.addressHouse, addressNumber = line.MainAHL.addressNumber, adressCity = line.MainAHL.adressCity, adressStreet = line.MainAHL.adressStreet, coordinateLatitude = line.MainAHL.coordinateLatitude, coordinateLongitude = line.MainAHL.coordinateLongitude, Floor = line.Floor, Id = line.idAHL, totalArea = line.MainAHL.totalArea, Type = "Дом" };
                output.Add(res);
            }
            foreach (var line in Models.context.aGetContext().Lands.Include(p => p.MainAHL))
            {
                var res = new Models.OutputHouse { addressHouse = line.MainAHL.addressHouse, addressNumber = line.MainAHL.addressNumber, adressCity = line.MainAHL.adressCity, adressStreet = line.MainAHL.adressStreet, coordinateLatitude = line.MainAHL.coordinateLatitude, coordinateLongitude = line.MainAHL.coordinateLongitude, Id = line.idAHL, totalArea = line.MainAHL.totalArea, Type = "Земля" };
                output.Add(res);
            }
            return output;
        }
    }
}
