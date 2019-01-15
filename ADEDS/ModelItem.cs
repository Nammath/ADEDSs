using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class ModelItem
    {
        private string _name;
        private string _type;
        private string _model;
        private string _series;
        private double _price;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public string Series
        {
            get { return _series; }
            set { _series = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
