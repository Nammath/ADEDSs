using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class DeliveryDisplay : Observer
    {
        public List<Delivery> deliveryList = new List<Delivery>();
        public int numberOfUpdates = 0;

        public override void Update()
        {
            Console.WriteLine("Nastapila jakas zmiana, ale nie wiadomo jaka.");
        }

        public void Update(Delivery d)
        {
            Console.WriteLine("Zamowienie " + d.ToString() + " zostalo zmienione!");
            numberOfUpdates++;
        }
    }
}
