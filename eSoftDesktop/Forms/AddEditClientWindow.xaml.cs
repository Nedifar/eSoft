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
    /// Логика взаимодействия для AddEditClientWindow.xaml
    /// </summary>
    public partial class AddEditClientWindow : Window
    {
        private Models.Client client = new Models.Client();
        public AddEditClientWindow(Models.Client _client)
        {
            InitializeComponent();
            if (_client != null)
                client = _client;
            DataContext = client;
        }

        private void clSAve(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(client.eMail) && String.IsNullOrWhiteSpace(client.Telephone))
            {
                MessageBox.Show("Error");
            }
            else
            {
                if (client.clientId== 0)
                {
                    Models.contetx.aGetContext().Clients.Add(client);
                }
                Models.contetx.aGetContext().SaveChanges();
                MessageBox.Show("Saved");
                Close();
            }
        }
    }
}
