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
                        cb.SelectedIndex = 0;
                        break;
                    case "Апарматенты":
                        cb.SelectedIndex = 1;
                        break;
                    case "Земля":
                        cb.SelectedIndex = 2;
                        break;
                }
            }
            DataContext = ou;
        }

        private void clSAve(object sender, RoutedEventArgs e)
        {
            if (ou.Id == 0)
            {
                switch (cb.SelectedIndex)
                {
                    case 0:
                        Models.contetx.aGetContext().Houses.Add(new Models.House { addressHouse = ou.addressHouse, addressNumber = ou.addressNumber, adressCity = ou.adressCity, adressStreet = ou.adressStreet, coordinateLatitude = ou.coordinateLatitude, coordinateLongitude = ou.coordinateLongitude, Floor = ou.Floor, Id = ou.Id, totalArea = ou.totalArea });
                        Models.contetx.aGetContext().SaveChanges();
                        break;
                    case 1:
                        Models.contetx.aGetContext().Apartaments.Add(new Models.Apartament { addressHouse = ou.addressHouse, addressNumber = ou.addressNumber, adressCity = ou.adressCity, adressStreet = ou.adressStreet, coordinateLatitude = ou.coordinateLatitude, coordinateLongitude = ou.coordinateLongitude, Floor = ou.Floor, Id = ou.Id, Rooms = ou.Rooms, totalArea = ou.totalArea });
                        Models.contetx.aGetContext().SaveChanges();
                        break;
                    case 2:
                        Models.contetx.aGetContext().Lands.Add(new Models.Land { addressHouse = ou.addressHouse, addressNumber = ou.addressNumber, adressCity = ou.adressCity, adressStreet = ou.adressStreet, coordinateLatitude = ou.coordinateLatitude, coordinateLongitude = ou.coordinateLongitude, Id = ou.Id, totalArea = ou.totalArea });
                        Models.contetx.aGetContext().SaveChanges();
                        break;
                }
            }
            else
            {
                switch (cb.SelectedIndex)
                {
                    case 0:
                        var a = Models.contetx.aGetContext().Houses.Where(p => p.Id == ou.Id).FirstOrDefault();
                        if (a == null)
                            a = new Models.House();
                        a.addressHouse = ou.addressHouse;
                        a.addressNumber = ou.addressNumber;
                        a.adressCity = ou.adressCity;
                        a.adressStreet = ou.adressStreet;
                        a.coordinateLatitude = ou.coordinateLatitude;
                        a.coordinateLongitude = ou.coordinateLongitude;
                        a.Floor = ou.Floor;
                        a.totalArea = ou.totalArea;
                        Models.contetx.aGetContext().SaveChanges();
                        break;
                    case 1:
                        var b = Models.contetx.aGetContext().Apartaments.Where(p => p.Id == ou.Id).FirstOrDefault();
                        if (b == null)
                            b = new Models.Apartament();
                        b.addressHouse = ou.addressHouse;
                        b.addressNumber = ou.addressNumber;
                        b.adressCity = ou.adressCity;
                        b.adressStreet = ou.adressStreet;
                        b.coordinateLatitude = ou.coordinateLatitude;
                        b.coordinateLongitude = ou.coordinateLongitude;
                        b.Floor = ou.Floor;
                        b.totalArea = ou.totalArea;
                        b.Rooms = ou.Rooms;
                        Models.contetx.aGetContext().SaveChanges();
                        break;
                    case 2:
                        var c = Models.contetx.aGetContext().Lands.Where(p => p.Id == ou.Id).FirstOrDefault();
                        if (c == null)
                            c = new Models.Land();
                        c.addressHouse = ou.addressHouse;
                        c.addressNumber = ou.addressNumber;
                        c.adressCity = ou.adressCity;
                        c.adressStreet = ou.adressStreet;
                        c.coordinateLatitude = ou.coordinateLatitude;
                        c.coordinateLongitude = ou.coordinateLongitude;
                        c.totalArea = ou.totalArea;
                        Models.contetx.aGetContext().SaveChanges();
                        break;
                }
            }
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
