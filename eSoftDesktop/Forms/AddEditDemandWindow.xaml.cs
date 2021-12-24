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
    /// Логика взаимодействия для AddEditDemandWindow.xaml
    /// </summary>
    public partial class AddEditDemandWindow : Window
    {
        private Models.Demand _demand = new Models.Demand();
        public AddEditDemandWindow(Models.Demand demand)
        {
            InitializeComponent();
            cb.ItemsSource = new string[] { "Дом", "Апартаменты", "Земля" };
            if (demand != null)
            {
                
                _demand = demand;
                switch (_demand.typeEstate)
                {
                    case "Дом":
                        cb.SelectedIndex = 0;
                        tbMinS.Text = _demand.HouseDemands.FirstOrDefault().minArea.ToString();
                        tbMaxS.Text = _demand.HouseDemands.FirstOrDefault().maxArea.ToString();
                        tbMinF.Text = _demand.HouseDemands.FirstOrDefault().minFloors.ToString();
                        tbMaxF.Text = _demand.HouseDemands.FirstOrDefault().maxFloors.ToString();
                        tbMinR.Text = _demand.HouseDemands.FirstOrDefault().minRooms.ToString();
                        tbMaxR.Text = _demand.HouseDemands.FirstOrDefault().maxRooms.ToString();
                        break;
                    case "Апарматенты":
                        cb.SelectedIndex = 1;
                        tbMinS.Text = _demand.ApartamentDemands.FirstOrDefault().minArea.ToString();
                        tbMaxS.Text = _demand.ApartamentDemands.FirstOrDefault().maxArea.ToString();
                        tbMinF.Text = _demand.ApartamentDemands.FirstOrDefault().minFloors.ToString();
                        tbMaxF.Text = _demand.ApartamentDemands.FirstOrDefault().maxFloors.ToString();
                        tbMinR.Text = _demand.ApartamentDemands.FirstOrDefault().minRooms.ToString();
                        tbMaxR.Text = _demand.ApartamentDemands.FirstOrDefault().maxRooms.ToString();
                        break;
                    case "Земля":
                        cb.SelectedIndex = 2;
                        tbMinS.Text = _demand.LandDemands.FirstOrDefault().minArea.ToString();
                        tbMaxS.Text = _demand.LandDemands.FirstOrDefault().maxArea.ToString();
                        break;
                }
            }
            cbClients.ItemsSource = Models.context.aGetContext().Clients.ToList();
            cbRealtors.ItemsSource = Models.context.aGetContext().Realtors.ToList();
            DataContext = _demand;
        }

        private void clSAve(object sender, RoutedEventArgs e)
        {
            if (_demand.idDemand == 0)
            {
                _demand.typeEstate = cb.Text;
                switch (cb.SelectedIndex)
                {
                    case 0:
                        Models.HouseDemand house = new Models.HouseDemand { minArea = int.Parse(tbMinS.Text), maxArea = int.Parse(tbMaxS.Text), minRooms = int.Parse(tbMinR.Text), maxRooms = int.Parse(tbMaxR.Text), minFloors = int.Parse(tbMinF.Text), maxFloors = int.Parse(tbMaxF.Text) };
                        _demand.HouseDemands.Add(house);
                        Models.context.aGetContext().Demands.Add(_demand);
                        Models.context.aGetContext().HouseDemands.Add(house);
                        Models.context.aGetContext().SaveChanges();
                        break;
                    case 1:
                        Models.ApartamentDemand apart = new Models.ApartamentDemand { minArea = int.Parse(tbMinS.Text), maxArea = int.Parse(tbMaxS.Text), minRooms = int.Parse(tbMinR.Text), maxRooms = int.Parse(tbMaxR.Text), minFloors = int.Parse(tbMinF.Text), maxFloors = int.Parse(tbMaxF.Text) };
                        _demand.ApartamentDemands.Add(apart);
                        Models.context.aGetContext().Demands.Add(_demand);
                        Models.context.aGetContext().ApartamentDemands.Add(apart);
                        Models.context.aGetContext().SaveChanges();
                        break;
                    case 2:
                        Models.LandDemand land = new Models.LandDemand { minArea = int.Parse(tbMinS.Text), maxArea = int.Parse(tbMaxS.Text)};
                        _demand.LandDemands.Add(land);
                        Models.context.aGetContext().Demands.Add(_demand);
                        Models.context.aGetContext().LandDemands.Add(land);
                        Models.context.aGetContext().SaveChanges();
                        break;
                }
            }
            else
            {
                switch (cb.SelectedIndex)
                {
                    case 0:
                        var a = _demand.HouseDemands.FirstOrDefault();
                        a.minArea = int.Parse(tbMinS.Text);
                        a.maxArea = int.Parse(tbMaxS.Text);
                        a.minRooms = int.Parse(tbMinR.Text);
                        a.maxRooms = int.Parse(tbMaxR.Text);
                        a.minFloors = int.Parse(tbMinF.Text);
                        a.maxFloors = int.Parse(tbMaxF.Text);
                        Models.context.aGetContext().SaveChanges();
                        break;
                    case 1:
                        var b = _demand.ApartamentDemands.FirstOrDefault();
                        b.minArea = int.Parse(tbMinS.Text);
                        b.maxArea = int.Parse(tbMaxS.Text);
                        b.minRooms = int.Parse(tbMinR.Text);
                        b.maxRooms = int.Parse(tbMaxR.Text);
                        b.minFloors = int.Parse(tbMinF.Text);
                        b.maxFloors = int.Parse(tbMaxF.Text);
                        Models.context.aGetContext().SaveChanges();
                        break;
                    case 2:
                        var c = _demand.LandDemands.FirstOrDefault();
                        c.minArea = int.Parse(tbMinS.Text);
                        c.maxArea = int.Parse(tbMaxS.Text);
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
                    tbMinR.Visibility = Visibility.Visible;
                    tbMaxR.Visibility = Visibility.Visible;
                    tbMinF.Visibility = Visibility.Visible;
                    tbMaxF.Visibility = Visibility.Visible;
                    tblMinR.Visibility = Visibility.Visible;
                    tblMaxR.Visibility = Visibility.Visible;
                    tblMinF.Visibility = Visibility.Visible;
                    tblMaxF.Visibility = Visibility.Visible;
                    break;
                case 1:
                    tbMinR.Visibility = Visibility.Visible;
                    tbMaxR.Visibility = Visibility.Visible;
                    tbMinF.Visibility = Visibility.Visible;
                    tbMaxF.Visibility = Visibility.Visible;
                    tblMinR.Visibility = Visibility.Visible;
                    tblMaxR.Visibility = Visibility.Visible;
                    tblMinF.Visibility = Visibility.Visible;
                    tblMaxF.Visibility = Visibility.Visible;
                    break;
                case 2:
                    tbMinR.Visibility = Visibility.Collapsed;
                    tbMaxR.Visibility = Visibility.Collapsed;
                    tbMinF.Visibility = Visibility.Collapsed;
                    tbMaxF.Visibility = Visibility.Collapsed;
                    tblMinR.Visibility = Visibility.Collapsed;
                    tblMaxR.Visibility = Visibility.Collapsed;
                    tblMinF.Visibility = Visibility.Collapsed;
                    tblMaxF.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}
