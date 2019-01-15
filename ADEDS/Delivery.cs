using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class Delivery : Subject
    {
        private bool finished = false;
        private Dictionary<ModelItem, SpecificItem> shipmentList;

        public Delivery(Order o)
         {



         }

        public void Finished()
        {
            finished = true;
            Notify();
        }

        public void NotFinished()
        {
            finished = false;
            Notify();
        }

        public bool IsFinished()
        {
            return finished;
        }

        public void Attach(DeliveryDisplay dd)
        {
            Register(dd);
            dd.deliveryList.Add(this);
        }

        public void Detach(DeliveryDisplay dd)
        {
            UnRegister(dd);
            dd.deliveryList.Remove(this);
        }

        public override void Notify()
        {
            foreach (DeliveryDisplay observer in observersList)
            {
                observer.Update(this);
            }
        }

    }
}
