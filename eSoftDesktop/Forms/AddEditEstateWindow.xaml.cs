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
                var main = new Models.MainAHL { addressHouse = ou.addressHouse, addressNumber = ou.addressNumber, adressCity = ou.adressCity, adressStreet = ou.adressStreet, coordinateLatitude = ou.coordinateLatitude, coordinateLongitude = ou.coordinateLongitude, totalArea = ou.totalArea };
                switch (cb.SelectedIndex)
                {
                    case 0:
                        Models.context.aGetContext().MainAHLs.Add(main);
                        Models.context.aGetContext().Houses.Add(new Models.House { Floor = ou.Floor, MainAHL = main });
                        Models.context.aGetContext().SaveChanges();
                        break;
                    case 1:
                        Models.context.aGetContext().MainAHLs.Add(main);
                        Models.context.aGetContext().Apartaments.Add(new Models.Apartament { Floor = ou.Floor, Rooms = ou.Rooms, MainAHL = main });
                        Models.context.aGetContext().SaveChanges();
                        break;
                    case 2:
                        Models.context.aGetContext().MainAHLs.Add(main);
                        Models.context.aGetContext().Lands.Add(new Models.Land { MainAHL = main });
                        Models.context.aGetContext().SaveChanges();
                        break;
                }
            }
            else
            {
                var main = Models.context.aGetContext().MainAHLs.Where(p => p.idAHL == ou.Id).FirstOrDefault();
                switch (cb.SelectedIndex)
                {
                    case 0:
                        var a = Models.context.aGetContext().Houses.Where(p => p.idAHL == ou.Id).FirstOrDefault();
                        if (a == null)
                            a = new Models.House();
                        main.addressHouse = ou.addressHouse;
                        main.addressNumber = ou.addressNumber;
                        main.adressCity = ou.adressCity;
                        main.adressStreet = ou.adressStreet;
                        main.coordinateLatitude = ou.coordinateLatitude;
                        main.coordinateLongitude = ou.coordinateLongitude;
                        a.Floor = ou.Floor;
                        main.totalArea = ou.totalArea;
                        Models.context.aGetContext().SaveChanges();
                        break;
                    case 1:
                        var b = Models.context.aGetContext().Apartaments.Where(p => p.idAHL == ou.Id).FirstOrDefault();
                        if (b == null)
                            b = new Models.Apartament();
                        main.addressHouse = ou.addressHouse;
                        main.addressNumber = ou.addressNumber;
                        main.adressCity = ou.adressCity;
                        main.adressStreet = ou.adressStreet;
                        main.coordinateLatitude = ou.coordinateLatitude;
                        main.coordinateLongitude = ou.coordinateLongitude;
                        b.Floor = ou.Floor;
                        main.totalArea = ou.totalArea;
                        b.Rooms = ou.Rooms;
                        Models.context.aGetContext().SaveChanges();
                        break;
                    case 2:
                        var c = Models.context.aGetContext().Lands.Where(p => p.idAHL == ou.Id).FirstOrDefault();
                        if (c == null)
                            c = new Models.Land();
                        main.addressHouse = ou.addressHouse;
                        main.addressNumber = ou.addressNumber;
                        main.adressCity = ou.adressCity;
                        main.adressStreet = ou.adressStreet;
                        main.coordinateLatitude = ou.coordinateLatitude;
                        main.coordinateLongitude = ou.coordinateLongitude;
                        main.totalArea = ou.totalArea;
                        Models.context.aGetContext().SaveChanges();
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
