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
    /// Логика взаимодействия для AddEditEstateWindow.xaml
    /// </summary>
    public partial class AddEditEstateWindow : Window
    {
        Models.OutputHouse ou = new Models.OutputHouse();
        Models.Land land = new Models.Land();
        Models.House house = new Models.House();
        Models.Apartament apartament = new Models.Apartament();
        public AddEditEstateWindow(Models.OutputHouse output)
        {
            InitializeComponent();
            cb.ItemsSource = new string[] { "Дом", "Апартаменты", "Земля" };
            if(output!=null)
            {
                ou = output;
                switch (output.Type)
                {
                    case "Дом":
                        house = new Models.House { addressHouse = output.addressHouse, addressNumber = output.addressNumber, adressCity = output.adressCity, adressStreet = output.adressStreet, coordinateLatitude = output.coordinateLatitude, coordinateLongitude = output.coordinateLongitude, Floor = output.Floor, Id = output.Id, totalArea = output.totalArea };
                        DataContext = house;
                        cb.SelectedIndex = 0;
                        break;
                    case "Апарматенты":
                        apartament  = new Models.Apartament { addressHouse = output.addressHouse, addressNumber = output.addressNumber, adressCity = output.adressCity, adressStreet = output.adressStreet, coordinateLatitude = output.coordinateLatitude, coordinateLongitude = output.coordinateLongitude, Floor = output.Floor, Id = output.Id, Rooms = output.Rooms, totalArea = output.totalArea };
                        DataContext = apartament;
                        cb.SelectedIndex = 1;
                        break;
                    case "Земля":
                        land = new Models.Land { addressHouse = output.addressHouse, addressNumber = output.addressNumber, adressCity = output.adressCity, adressStreet = output.adressStreet, coordinateLatitude = output.coordinateLatitude, coordinateLongitude = output.coordinateLongitude, Id = output.Id, totalArea = output.totalArea };
                        DataContext = land;
                        cb.SelectedIndex = 2;
                        break;
                }
            }
        }

        private void clSAve(object sender, RoutedEventArgs e)
        {
            if (ou.Id == 0)
            {
                switch (cb.SelectedIndex)
                {
                    case 0:
                        Models.contetx.aGetContext().Houses.Add(house);
                        Models.contetx.aGetContext().SaveChanges();
                        break;
                    case 1:
                        Models.contetx.aGetContext().Apartaments.Add(apartament);
                        Models.contetx.aGetContext().SaveChanges();
                        break;
                    case 2:
                        Models.contetx.aGetContext().Lands.Add(land);
                        Models.contetx.aGetContext().SaveChanges();
                        break;
                }
            }
            else
                Models.contetx.aGetContext().SaveChanges();
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb.SelectedIndex)
            {
                case 0:
                    tbF.Visibility = Visibility.Visible;
                    tboF.Visibility = Visibility.Visible;
                    tbR.Visibility = Visibility.Collapsed;
                    tboL.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    tbF.Visibility = Visibility.Visible;
                    tboF.Visibility = Visibility.Visible;
                    tbR.Visibility = Visibility.Visible;
                    tboL.Visibility = Visibility.Visible;
                    break;
                case 2:
                    tbF.Visibility = Visibility.Collapsed;
                    tboF.Visibility = Visibility.Collapsed;
                    tbR.Visibility = Visibility.Collapsed;
                    tboL.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}
