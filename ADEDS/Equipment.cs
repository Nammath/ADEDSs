using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public abstract class EquipmentTemplate
    {
        protected abstract void SetName(string name);
        protected abstract void SetMileage(int mileage);
        protected abstract void SetState(bool state);

        public void SetParameters(string name, int mileage, bool state)
        {
            SetName(name);
            SetMileage(mileage);
            SetState(state);
        }
    }

    public class Vehicle : EquipmentTemplate
    {
        private string name;
        private int mileage;
        private bool state;

        protected override void SetMileage(int mileage)
        {
            try
            {
                if (mileage < 0)
                {
                    throw new ArgumentException();
                }
                else if (mileage.Equals(null))
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.mileage = mileage;
                }
            }
            catch (ArgumentException)
            {
                mileage = 0;
            }
        }

        protected override void SetName(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                this.name = name;
            }
            else
            {
                name = "Unnamed Vehicle";
            }
        }

        protected override void SetState(bool state)
        {
            this.state = state;
        }
    }

    public class Tool : EquipmentTemplate
    {
        private string name;
        private bool state;

        protected override void SetMileage(int mileage)
        {
            if (!mileage.Equals(null))
            {
            //    throw new ArgumentException();
            }
        }

        protected override void SetName(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                this.name = name;
            }
            else
            {
                name = "Unnamed Tool";
            }
        }

        protected override void SetState(bool state)
        {
            this.state = state;
        }
    }
}
