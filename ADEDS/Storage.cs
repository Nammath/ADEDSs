using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class Storage
    {
        private Dictionary<SpecificItem, ModelItem> listOfItems;
        private List<ModelItem> listOfModelItems;

        private static Storage storage = new Storage();
        private Storage()
        {
            listOfItems = new Dictionary<SpecificItem, ModelItem>();
            listOfModelItems = new List<ModelItem>();

        }

        public SpecificItem GetUnsoldItem(ModelItem item)
        {
            foreach (var tempItem in listOfItems)
                if (tempItem.Value.Equals(item) && !tempItem.Key.IsSold())
                    { tempItem.Key.Sold();
                    return tempItem.Key; }
            return null;

        }

        public void AddItem(SpecificItem spItem, ModelItem mdItem)
        {

            listOfItems.Add(spItem, mdItem);
        }

        public static Storage getStorageInstance()
        {
            return storage;
        }
    }
}
