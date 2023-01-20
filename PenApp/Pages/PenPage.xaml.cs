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
    /// Interaction logic for PenPAge.xaml
    /// </summary>
    public partial class PenPage : Page
    {
        public Pen Pen { get; set; }
        public List<PenType> PenTypes { get; set; }
        public List<Company> Companies { get; set; }

        public PenPage(Pen pen)
        {
            InitializeComponent();
            Pen = pen;
            PenTypes = DataAccess.GetPenTypes();
            Companies = DataAccess.GetCompanies();
            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.SavePen(Pen);
            NavigationService.GoBack();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                DataAccess.DeletePen(Pen);
                NavigationService.GoBack();
            }
        }
    }
}
