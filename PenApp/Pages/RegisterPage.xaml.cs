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
using PenApp.DataBase;


namespace PenApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public List<CustomerType> CustomerTypes { get; set; }
        public RegisterPage()
        {
            InitializeComponent();
            CustomerTypes = DataAccess.GetCustomerTypes();
            DataContext = this;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var stringBuilder = new StringBuilder();
            try
            {
                if (tbLogin.Text == "")
                    stringBuilder.AppendLine("Запоните логин");
                if (pbPassword.Password == "")
                    stringBuilder.AppendLine("Зполните пароль");
                if (pbPassword.Password != pbConfirmPassword.Password)
                    stringBuilder.AppendLine("Пароли не совпадают");
                if (tbName.Text == "")
                    stringBuilder.AppendLine("Заполните название");
                if (tbAddress.Text == "")
                    stringBuilder.AppendLine("Заполните адрес");
                if (cbType.SelectedItem == null)
                    stringBuilder.AppendLine("Выберите тип");

                if (stringBuilder.Length > 0)
                {
                    MessageBox.Show(stringBuilder.ToString());
                    return;
                }


                var user = new User()
                {
                    Login = tbLogin.Text,
                    Password = pbPassword.Password.ToString(),
                    Customer = new Customer
                    {
                        CustomerType = cbType.SelectedItem as CustomerType,
                        Name = tbName.Text,
                        Address = tbAddress.Text,
                    }
                };
                DataAccess.SaveUser(user);
                App.User = user;
                NavigationService.Navigate(new PenListPage());
            }
            catch
            {
                MessageBox.Show("Такой логин уже занят");
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
