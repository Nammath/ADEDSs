using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class Iterator
    {
        protected List<Worker> List;
        protected int Counter;

        public Iterator(List<Worker> List)
        {
            this.List = List;
            Counter = -1;
        }

        public virtual bool HasNext()
        {
            try
            {
                if (List == null)
                {
                    return false;
                }
                else
                {
                    if (List[Counter + 1] != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
        public virtual Worker Next()
        {
            return List[Counter++];
        }
    }

    public class ManagerIterator : Iterator
    {
        public ManagerIterator(List<Worker> List) : base(List)
        {
            this.List = List;
        }

        public override bool HasNext()
        {
            try
            {
                while (List[Counter + 1] != null)
                {
                    if (List[Counter + 1].GetType() == typeof(Manager))
                    {
                        return true;
                    }
                    else
                    {
                        Counter++;
                    }
                }
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
        public override Worker Next()
        {
            return List[Counter++];
        }
    }

    public class ITSpecialistIterator : Iterator
    {
        public ITSpecialistIterator(List<Worker> List) : base(List)
        {
            this.List = List;
        }

        public override bool HasNext()
        {
            try
            {
                while (List[Counter + 1] != null)
                {
                    if (List[Counter + 1].GetType() == typeof(ITSpecialist))
                    {
                        return true;
                    }
                    else
                    {
                        Counter++;
                    }
                }
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
        public override Worker Next()
        {
            return List[Counter++];
        }
    }
}
