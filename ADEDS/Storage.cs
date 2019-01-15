using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class Storage
    {
        private Dictionary<ModelItem, SpecificItem> listOfItems;
        private List<ModelItem> listOfModelItems;
        private List<Order> listOfOrders;

        private static Storage storage = new Storage();
        private Storage()
        {
            listOfItems = new Dictionary<ModelItem, SpecificItem>();
            listOfModelItems = new List<ModelItem>();
            listOfOrders = new List<Order>();

            ModelItem modelItem = new ModelItem();
            modelItem.Model = "test model";
            modelItem.Name = "test name";
            modelItem.Price = 2.50;
            modelItem.Series = "test series";
            modelItem.Type = "test type";

            ModelItem modelItem2 = new ModelItem();
            modelItem2.Model = "test2 model";
            modelItem2.Name = "test2 name";
            modelItem2.Price = 2.50;
            modelItem2.Series = "test2 series";
            modelItem2.Type = "test2 type";

            listOfModelItems.Add(modelItem);
            listOfModelItems.Add(modelItem2);
        }

        public SpecificItem RequestItem(ModelItem item)
        {
            //Trzeba jakos dodac zwracanie pierwszego SpecificItem, ktory ma klucz item i ktorego IsSold == false
            return null;

        }

        public void AddItem(SpecificItem spItem, ModelItem mdItem)
        {
            listOfItems.Add(mdItem, spItem);
        }

        public List<ModelItem> getListOfModelItems()
        {
            return listOfModelItems;
        }

        public static Storage getStorageInstance()
        {
            return storage;
        }
        public void addOrder(Order order)
        {
            listOfOrders.Add(order);
        }
    }
}
