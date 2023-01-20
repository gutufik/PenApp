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
        public OrderListPage()
        {
            InitializeComponent();
            Orders = DataAccess.GetOrders();
            DataAccess.RefreshhList += DataAccess_RefreshhList;
            DataContext = this;
        }

        private void DataAccess_RefreshhList()
        {
            Orders = DataAccess.GetOrders();
            lvOrders.ItemsSource = Orders;
            lvOrders.Items.Refresh();
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
    }
}
