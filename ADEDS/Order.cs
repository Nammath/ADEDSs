using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class Order
    {
        private string _name;
        private string _phone;
        private string _address;
        private int _amount;
        private ModelItem _item;

        // Gets or sets name

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or sets phone

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        // Gets or sets budget

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public ModelItem Item
        {
            get { return _item; }
            set { _item = value; }
        }

        public OrderMemento SaveMemento()
        {
            return new OrderMemento(_name, _phone, _address, _amount, _item);
        }

        // Restores memento

        public void RestoreMemento(OrderMemento memento)
        {
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Address = memento.Address;
            this.Amount = memento.Amount;
        }
    }
}
