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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PenApp.Pages
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public Order Order { get; set; }
        public List<Pen> Pens { get; set; }

        public OrderPage(Order order)
        {
            InitializeComponent();
            Order = order;
            Pens = DataAccess.GetPens();
            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.SaveOrder(Order);
            NavigationService.GoBack();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                DataAccess.DeleteOrder(Order);
                NavigationService.GoBack();
            }
        }
    }
}
