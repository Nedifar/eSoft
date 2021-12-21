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
    /// Логика взаимодействия для EstateForm.xaml
    /// </summary>
    public partial class EstateForm : Window
    {
        List<Models.OutputHouse> outputs = new List<Models.OutputHouse>();
        List<Models.OutputHouse> outputs1 = new List<Models.OutputHouse>();
        List<Models.OutputHouse> outputs2 = new List<Models.OutputHouse>();
        public EstateForm()
        {
            InitializeComponent();
            outputs = getListForDG();
            dgEstates.ItemsSource = outputs;
            outputs1 = outputs;
            outputs2 = outputs;
            typeFilter.ItemsSource = new string[] { "Не выбрано", "Дом", "Апартаменты", "Земля" };
            addressFilter.ItemsSource = outputs.ToList();
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            AddEditEstateWindow add = new AddEditEstateWindow(null);
            add.Show();
            add.IsVisibleChanged += Add_IsVisibleChanged;
        }

        private void Add_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender as Window).Visibility == Visibility.Visible)
            {
                outputs = getListForDG();
                dgEstates.ItemsSource = outputs;
                outputs1 = outputs;
                outputs2 = outputs;
            }
            else
            { }

        }

        private void clDelete(object sender, RoutedEventArgs e)
        {
            if (dgEstates.SelectedItem != null)
            {
                int i = (dgEstates.SelectedItem as Models.OutputHouse).Id;
                switch ((dgEstates.SelectedItem as Models.OutputHouse).Type)
                {
                    case "Дом":
                        var ho = Models.contetx.aGetContext().Houses.Where(p => p.Id == i).FirstOrDefault();
                        Models.contetx.aGetContext().Houses.Remove(ho);
                        break;
                    case "Апарматенты":
                        var apa = Models.contetx.aGetContext().Apartaments.Where(p => p.Id == i).FirstOrDefault();
                        Models.contetx.aGetContext().Apartaments.Remove(apa);
                        break;
                    case "Земля":
                        var la = Models.contetx.aGetContext().Lands.Where(p=>p.Id==i).FirstOrDefault();
                        Models.contetx.aGetContext().Lands.Remove(la);
                        break;
                }
                Models.contetx.aGetContext().SaveChanges();
                outputs = getListForDG();
                dgEstates.ItemsSource = outputs;
                outputs1 = outputs;
                outputs2 = outputs;
            }
            else
                MessageBox.Show("Выберите объект для операции!");

        }

        private void clEdit(object sender, RoutedEventArgs e)
        {
            if (dgEstates.SelectedItem != null)
            {
                AddEditEstateWindow add = new AddEditEstateWindow(dgEstates.SelectedItem as Models.OutputHouse);
                add.Show();
            }
            else
                MessageBox.Show("Выберите объект для операции!");
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text != "")
            {
                var list = new List<Models.Client>();
                foreach (var p in Models.contetx.aGetContext().Clients)
                {
                    if (LevenshteinDistance(p.lastName, search.Text) <= 3)
                        list.Add(p);
                    else if (LevenshteinDistance(p.Name, search.Text) <= 3)
                        list.Add(p);
                    else if (LevenshteinDistance(p.middleName, search.Text) <= 3)
                        list.Add(p);
                }
                dgEstates.ItemsSource = list;
            }
            else
            {
                outputs = getListForDG();
                dgEstates.ItemsSource = outputs;
                outputs1 = outputs;
                outputs2 = outputs;
            }

        }
        public static int LevenshteinDistance(string string1, string string2)
        {
            if (string1 == null) throw new ArgumentNullException("string1");
            if (string2 == null) throw new ArgumentNullException("string2");
            int diff;
            int[,] m = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
                }
            }
            return m[string1.Length, string2.Length];
        }

        public List<Models.OutputHouse> getListForDG()
        {
            List<Models.OutputHouse> output = new List<Models.OutputHouse>();
            foreach (var line in Models.contetx.aGetContext().Apartaments)
            {
                var res = new Models.OutputHouse { addressHouse = line.addressHouse, addressNumber = line.addressNumber, adressCity = line.adressCity, adressStreet = line.adressStreet, coordinateLatitude = line.coordinateLatitude, coordinateLongitude = line.coordinateLongitude, Floor = line.Floor, Id = line.Id, Rooms = line.Rooms, totalArea = line.totalArea, Type = "Апарматенты" };
                output.Add(res);
            }
            foreach (var line in Models.contetx.aGetContext().Houses)
            {
                var res = new Models.OutputHouse { addressHouse = line.addressHouse, addressNumber = line.addressNumber, adressCity = line.adressCity, adressStreet = line.adressStreet, coordinateLatitude = line.coordinateLatitude, coordinateLongitude = line.coordinateLongitude, Floor = line.Floor, Id = line.Id, totalArea = line.totalArea, Type = "Дом" };
                output.Add(res);
            }
            foreach (var line in Models.contetx.aGetContext().Lands)
            {
                var res = new Models.OutputHouse { addressHouse = line.addressHouse, addressNumber = line.addressNumber, adressCity = line.adressCity, adressStreet = line.adressStreet, coordinateLatitude = line.coordinateLatitude, coordinateLongitude = line.coordinateLongitude, Id = line.Id, totalArea = line.totalArea, Type = "Земля" };
                output.Add(res);
            }
            return output;
        }

        private void typeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (typeFilter.SelectedIndex)
            {
                case 0:
                    dgEstates.ItemsSource = outputs2;
                    break;
                case 1:
                    dgEstates.ItemsSource = outputs2.Where(p => p.Type == "Дом");
                    outputs1 = outputs2.Where(p => p.Type == "Дом").ToList();
                    break;
                case 2:
                    dgEstates.ItemsSource = outputs2.Where(p => p.Type == "Апарматенты");
                    outputs1 = outputs2.Where(p => p.Type == "Апарматенты").ToList();
                    break;
                case 3:
                    dgEstates.ItemsSource = outputs2.Where(p => p.Type == "Земля");
                    outputs1 = outputs2.Where(p => p.Type == "Земля").ToList();
                    break;
            }
        }

        private void addressFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(addressFilter.SelectedIndex == 0)
            {
                dgEstates.ItemsSource = outputs1;
            }
            else
            {
                string s = ((sender as ComboBox).SelectedItem as Models.OutputHouse).adressStreet;
                dgEstates.ItemsSource = outputs1.Where(p=>p.adressStreet ==s );
                outputs2 = outputs1.Where(p => p.adressStreet == s).ToList();

            }
        }
    }
}
