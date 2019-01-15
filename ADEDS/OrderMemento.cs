using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class OrderMemento
    {
        private string _name;
        private string _phone;
        private string _address;
        private int _amount;
        private ModelItem _item;

        // Constructor

        public OrderMemento(string name, string phone, string address, int amount, ModelItem item)
        {
            this._name = name;
            this._phone = phone;
            this._address = address;
            this._amount = amount;
            this._item = item;
        }

        // Gets or sets name

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or set phone

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
    }
}
