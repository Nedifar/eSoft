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
            var stream = File.ReadAllLines(@"C:\Users\gazimov.ii0794\Downloads\agents.txt");

            foreach (var line in stream)
            {
                var kk = new Models.District();
                kk.Name = line.Split('\t')[0];
                kk.area = line.Split('\t')[1];
                Models.contetx.aGetContext().Districts.Add(kk);
                Models.contetx.aGetContext().SaveChanges();
            }

        }

    }
}
