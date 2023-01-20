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
using System.Windows.Threading;

namespace PenApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        bool isHidden = true;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Timer_Tick;

            MainFrame.NavigationService.Navigate(new Pages.LoginPage());
            MainFrame.Navigated += MainFrame_Navigated;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isHidden)
            {
                menuGrid.Width += 2;
                if (menuGrid.Width >= 100)
                {
                    timer.Stop();
                    isHidden = false;
                }
            }
            else
            {
                menuGrid.Width -= 2;
                if (menuGrid.Width <= 0)
                {
                    timer.Stop();
                    isHidden = true;
                }
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            tbTitle.Text = (MainFrame.Content as Page).Title;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.NavigationService.GoBack();
        }

        private void btnGoForward_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoForward)
                MainFrame.NavigationService.GoForward();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void btnPens_Click(object sender, RoutedEventArgs e)
        {
            if (App.User == null)
                MessageBox.Show("You need to log in");
            else
                MainFrame.NavigationService.Navigate(new Pages.PenListPage());
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            if (App.User == null)
                MessageBox.Show("You need to log in");
            else
                MainFrame.NavigationService.Navigate(new Pages.OrderListPage());
        }
    }
}
