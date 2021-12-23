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
    /// Логика взаимодействия для RealtorForm.xaml
    /// </summary>
    public partial class RealtorForm : Window
    {
        public RealtorForm()
        {
            InitializeComponent();
            dgRealtors.ItemsSource = Models.context.aGetContext().Realtors.ToList();
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            AddEditRealtorWindow add = new AddEditRealtorWindow(null);
            add.Show();
            add.IsVisibleChanged += Add_IsVisibleChanged;
        }

        private void clDelete(object sender, RoutedEventArgs e)
        {
            if (dgRealtors.SelectedItem != null)
            {
                Models.context.aGetContext().Realtors.Remove(dgRealtors.SelectedItem as Models.Realtor);
                Models.context.aGetContext().SaveChanges();
            }
            else
                MessageBox.Show("Выберите объект для операции!");

        }
        private void Add_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender as Window).Visibility == Visibility.Visible)
            {
                dgRealtors.ItemsSource = Models.context.aGetContext().Realtors.ToList();
            }
            else
            { }

        }

        private void clEdit(object sender, RoutedEventArgs e)
        {
            if (dgRealtors.SelectedItem != null)
            {
                AddEditRealtorWindow add = new AddEditRealtorWindow(dgRealtors.SelectedItem as Models.Realtor);
                add.Show();
            }
            else
                MessageBox.Show("Выберите объект для операции!");
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text != "")
            {
                var list = new List<Models.Realtor>();
                foreach (var p in Models.context.aGetContext().Realtors)
                {
                    if (LevenshteinDistance(p.lastName, search.Text) <= 3)
                        list.Add(p);
                    else if (LevenshteinDistance(p.Name, search.Text) <= 3)
                        list.Add(p);
                    else if (LevenshteinDistance(p.middleName, search.Text) <= 3)
                        list.Add(p);
                }
                dgRealtors.ItemsSource = list;
            }
            else
                dgRealtors.ItemsSource = Models.context.aGetContext().Realtors.ToList();
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
    }
}
