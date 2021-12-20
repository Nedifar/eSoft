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
    /// Логика взаимодействия для AddEditRealtorWindow.xaml
    /// </summary>
    public partial class AddEditRealtorWindow : Window
    {
        private Models.Realtor realtor = new Models.Realtor();
        public AddEditRealtorWindow(Models.Realtor _realtor)
        {
            InitializeComponent();
            if (_realtor != null)
                realtor = _realtor;
            DataContext = realtor;
        }

        private void clSAve(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(realtor.lastName) || String.IsNullOrWhiteSpace(realtor.Name) || String.IsNullOrWhiteSpace(realtor.middleName) || realtor.comissionPart >100 || realtor.comissionPart<0 )
            {
                MessageBox.Show("Error");
            }
            else
            {
                if(realtor.realtorId ==0)
                {
                    Models.contetx.aGetContext().Realtors.Add(realtor);
                }
                Models.contetx.aGetContext().SaveChanges();
                MessageBox.Show("Saved");
                Close();
            }
        }
    }
}
