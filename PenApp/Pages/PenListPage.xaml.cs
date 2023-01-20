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
        DispatcherTimer Timer;
        bool hidden;
        public PenListPage()
        {
            InitializeComponent();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Timer.Tick += Timer_Tick;

            Pens = DataAccess.GetPens();
            DataAccess.RefreshhList += DataAccess_RefreshhList;
            DataContext = this;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                myRect.Width += 2;
                if (myRect.Width >= 200)
                {
                    Timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                myRect.Width -= 2;
                if (myRect.Width <= 10)
                {
                    Timer.Stop();
                    hidden = true;
                }
            }
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

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Timer.Start();
        }
    }
}
