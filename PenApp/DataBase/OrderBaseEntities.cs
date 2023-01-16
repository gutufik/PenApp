using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenApp.DataBase
{
    public partial class OrderBaseEntities
    {
        private static OrderBaseEntities context;

        public static OrderBaseEntities GetContext()
        {
            if (context == null)
                context = new OrderBaseEntities();
            return context;
        }
    }
}
