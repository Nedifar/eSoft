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
            cbClients.ItemsSource = Models.contetx.aGetContext().Clients.ToList();
            cbRealtors.ItemsSource = Models.contetx.aGetContext().Realtors.ToList();
            cbClients.ItemsSource = getListForDG();
            DataContext = supply;
        }

        private void clSAve(object sender, RoutedEventArgs e)
        {
            if (cbClients.SelectedIndex == -1 || cbHomes.SelectedIndex==-1 || cbRealtors.SelectedIndex==-1)
            {
                MessageBox.Show("Error");
            }
            else
            {
                if (supply.supplyId == 0)
                {
                    Models.contetx.aGetContext().Supplies.Add(supply);
                }
                Models.contetx.aGetContext().SaveChanges();
                MessageBox.Show("Saved");
                Close();
            }
        }
        public List<Models.OutputHouse> getListForDG()
        {
            List<Models.OutputHouse> output = new List<Models.OutputHouse>();
            foreach (var line in Models.contetx.aGetContext().Apartaments)
            {
                var res = new Models.OutputHouse { addressHouse = line.addressHouse, addressNumber = line.addressNumber, adressCity = line.adressCity, adressStreet = line.adressStreet, coordinateLatitude = line.coordinateLatitude, coordinateLongitude = line.coordinateLongitude, Floor = line.Floor, Id = line.homeId, Rooms = line.Rooms, totalArea = line.totalArea, Type = "Апарматенты" };
                output.Add(res);
            }
            foreach (var line in Models.contetx.aGetContext().Houses)
            {
                var res = new Models.OutputHouse { addressHouse = line.addressHouse, addressNumber = line.addressNumber, adressCity = line.adressCity, adressStreet = line.adressStreet, coordinateLatitude = line.coordinateLatitude, coordinateLongitude = line.coordinateLongitude, Floor = line.Floor, Id = line.homeId, totalArea = line.totalArea, Type = "Дом" };
                output.Add(res);
            }
            foreach (var line in Models.contetx.aGetContext().Lands)
            {
                var res = new Models.OutputHouse { addressHouse = line.addressHouse, addressNumber = line.addressNumber, adressCity = line.adressCity, adressStreet = line.adressStreet, coordinateLatitude = line.coordinateLatitude, coordinateLongitude = line.coordinateLongitude, Id = line.homeId, totalArea = line.totalArea, Type = "Земля" };
                output.Add(res);
            }
            return output;
        }
    }
}
