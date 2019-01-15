using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public abstract class Subject
     {

        public List<Observer> observersList = new List<Observer>();

        protected void Register(Observer observer)
        {
            observersList.Add(observer);
        }

        protected void UnRegister(Observer observer)
        {
            observersList.Remove(observer);
        }

        public abstract void Notify();

}
}
