using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ADEDS
{
    class Commands
    {
        public static RoutedUICommand Cart = new RoutedUICommand("Cart", "Cart", typeof(Commands));
        public static RoutedUICommand Order = new RoutedUICommand("Order", "Order", typeof(Commands));
    }
}
