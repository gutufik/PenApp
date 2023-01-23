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
        public List<DataBase.Pen> PensForFilters { get; set; }
        public List<PenType> PenTypes { get; set; }

        public Dictionary<string, Func<Pen, object>> Sortings { get; set; }

        public PenListPage()
        {
            InitializeComponent();

            Pens = DataAccess.GetPens();
            PenTypes = DataAccess.GetPenTypes();
            PenTypes.Insert(0, new PenType { Name = "Все" });
            Sortings = new Dictionary<string, Func<Pen, object>>
            {
                { "Сначала дорогие", x => x.Price },//reverse
                { "Сначала дешевые", x => x.Price },
                { "А-Я", x => x.Name },
                { "Я-А", x => x.Name } //reverse
            };

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

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (cbType.SelectedItem != null && cbSort.SelectedItem != null)
            {
                var searchText = tbSearch.Text;
                PensForFilters = Pens.FindAll(x => x.Name.Contains(searchText));
                var penType = cbType.SelectedItem as PenType;
                if (penType.Name != "Все")
                {
                    PensForFilters = PensForFilters.FindAll(x => x.PenType == penType);
                }
                var sort = cbSort.SelectedItem as string;
                PensForFilters = PensForFilters.OrderBy(Sortings[sort]).ToList();

                if (sort == "Я-А" || sort == "Сначала дорогие")
                    PensForFilters.Reverse();

                lvPens.ItemsSource = PensForFilters;
                lvPens.Items.Refresh();
            }
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }
    }
}
