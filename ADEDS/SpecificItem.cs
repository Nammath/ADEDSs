using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class SpecificItem
    {
        private string _serialNumber;
        private string _placeInStorage;
        private bool _sold = false;

        public bool IsSold()
        {
            return _sold;
        }

        public void Sold()
        {
            _sold = true;
        }

        public void NotSold()
        {
            _sold = false;
        }

        public string SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }

        public string PlaceInStorage
        {
            get { return _placeInStorage; }
            set { _placeInStorage = value; }
        }
    }
}
