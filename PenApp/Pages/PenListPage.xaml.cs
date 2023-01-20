using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using PenApp.DataBase;

namespace PenApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PenListPage.xaml
    /// </summary>
    public partial class PenListPage : Page
    {
        public List<DataBase.Pen> Pens { get; set; }

        public PenListPage()
        {
            InitializeComponent();

            Pens = DataAccess.GetPens();
            DataAccess.RefreshhList += DataAccess_RefreshhList;
            DataContext = this;
        }

        private void DataAccess_RefreshhList()
        {
            Pens = DataAccess.GetPens();
            lvPens.ItemsSource = Pens;
            lvPens.Items.Refresh();
        }

        private void lvPens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pen = lvPens.SelectedItem as DataBase.Pen;
            if (pen != null)
                NavigationService.Navigate(new PenPage(pen));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PenPage(new DataBase.Pen()));
        }
    }
}
