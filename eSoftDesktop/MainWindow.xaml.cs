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
            var stream = File.ReadAllLines(@"C:\Users\gazimov.ii0794\Downloads\agents.txt");

            foreach (var line in stream)
            {
                var main = new Models.Supply();
                string[] massiv = line.Split('\t');
                main.Price = int.Parse(massiv[1]);
                main.idRealtor = int.Parse(massiv[2]);
                main.idClient = int.Parse(massiv[3]);
                main.idAHL = int.Parse(massiv[4]);
                //kk.idAHL = int.Parse(massiv[2]);
                //kk.Price = int.Parse(massiv[3]);
                Models.context.aGetContext().Supplies.Add(main);
                Models.context.aGetContext().SaveChanges();
                //var kk = new Models.District();
                //string[] massiv = line.Split('\t');
                //kk.Name = massiv[0];
                //kk.area = massiv[1];
                //Models.context.aGetContext().Districts.Add(kk);
                //Models.context.aGetContext().SaveChanges();
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
