using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PenApp.DataBase
{
    public class DataAccess
    {
        public delegate void RefreshhListDelegate();
        public static event RefreshhListDelegate RefreshhList;

        public static List<User> GetUsers() => OrderBaseEntities.GetContext().Users.ToList();

        public static List<Order> GetOrders() => OrderBaseEntities.GetContext().Orders.ToList();

        public static List<Customer> GetCustomers() => OrderBaseEntities.GetContext().Customers.ToList();
        
        public static List<CustomerType> GetCustomerTypes() => OrderBaseEntities.GetContext().CustomerTypes.ToList();
        
        public static List<Company> GetCompanies() => OrderBaseEntities.GetContext().Companies.ToList();

        public static List<Pen> GetPens() => OrderBaseEntities.GetContext().Pens.ToList();

        public static List<PenType> GetPenTypes() => OrderBaseEntities.GetContext().PenTypes.ToList();

        public static User GetUser(string login, string password) => GetUsers().FirstOrDefault(x => x.Login == login && x.Password == password);

        public static List<Order> GetOrders(User user) => GetOrders().FindAll(x => x.Customer == user.Customer);

        public static void SaveUser(User user)
        {
            if (user.Id == 0)
                OrderBaseEntities.GetContext().Users.Add(user);

            OrderBaseEntities.GetContext().SaveChanges();
            RefreshhList?.Invoke();
        }

        internal static void SaveOrder(Order order)
        {
            if (order.Id == 0)
                OrderBaseEntities.GetContext().Orders.Add(order);

            OrderBaseEntities.GetContext().SaveChanges();
            RefreshhList?.Invoke();
        }

        internal static void DeleteOrder(Order order)
        {
            OrderBaseEntities.GetContext().Orders.Remove(order);
            OrderBaseEntities.GetContext().SaveChanges();
            RefreshhList?.Invoke();
        }

        internal static void SavePen(Pen pen)
        {
            if (pen.Id == 0)
                OrderBaseEntities.GetContext().Pens.Add(pen);

            OrderBaseEntities.GetContext().SaveChanges();
            RefreshhList?.Invoke();
        }

        internal static void DeletePen(Pen pen)
        {
            OrderBaseEntities.GetContext().Pens.Remove(pen);
            OrderBaseEntities.GetContext().SaveChanges();
            RefreshhList?.Invoke();
        }
    }
}
