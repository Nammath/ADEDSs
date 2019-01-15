using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class ArchivedOrder
    {
        private OrderMemento _memento;

        public OrderMemento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
