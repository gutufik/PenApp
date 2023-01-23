using PenApp.DataBase;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PenApp.Pages
{
    /// <summary>
    /// Interaction logic for OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        public List<Order> Orders { get; set; }
        public List<Order> OrdersForFilters { get; set; }

        public List<PenType> PenTypes { get; set; }
        public Dictionary<string, Func<Order, object>> Sortings { get; set; }
        public OrderListPage()
        {
            InitializeComponent();
            Orders = DataAccess.GetOrders(App.User);
            PenTypes = DataAccess.GetPenTypes();
            PenTypes.Insert(0, new PenType() { Name = "Все" });
            Sortings = new Dictionary<string, Func<Order, object>>
            {
                { "Сначала старые", x => x.Date },//reverse
                { "Сначала новые", x => x.Date },
            };
            DataAccess.RefreshhList += DataAccess_RefreshhList;
            DataContext = this;
        }

        private void DataAccess_RefreshhList()
        {
            Orders = DataAccess.GetOrders();
            lvOrders.ItemsSource = Orders;
            lvOrders.Items.Refresh();
        }

        private void ApplyFilters()
        {
            if (cbType.SelectedItem != null && cbSort.SelectedItem != null)
            {
                var searchText = tbSearch.Text;
                OrdersForFilters = Orders.FindAll(x => x.Pen.Name.Contains(searchText));
                var penType = cbType.SelectedItem as PenType;
                if (penType.Name != "Все")
                {
                    OrdersForFilters = OrdersForFilters.FindAll(x => x.Pen.PenType == penType);
                }
                var sort = cbSort.SelectedItem as string;
                OrdersForFilters = OrdersForFilters.OrderBy(Sortings[sort]).ToList();

                if (sort == "Сначала старые")
                    OrdersForFilters.Reverse();

                lvOrders.ItemsSource = OrdersForFilters;
                lvOrders.Items.Refresh();
            }
        }

        private void lvOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var order = lvOrders.SelectedItem as DataBase.Order;
            if (order != null)
                NavigationService.Navigate(new OrderPage(order));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage(new Order()));
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }
    }
}
