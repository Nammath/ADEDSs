using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADEDS.UnitTests
{
    [TestClass]
    public class MementoTests
    {
        [TestMethod]
        public void SaveMemento_MementoCreated_MementoSameAsOriginal()
        {
            Order o = new Order();
            Order o2 = new Order();
            ArchivedOrder ao = new ArchivedOrder();
            o.Name = "ABC";
            o.Phone = "123456789";
            o.Address = "DEF 123";
            o.Amount = 10;

            ao.Memento = o.SaveMemento();
            o2.RestoreMemento(ao.Memento);

            Assert.IsTrue(o.Name.Equals(o2.Name)
                && o.Phone.Equals(o2.Phone)
                && o.Address.Equals(o2.Address)
                && o.Amount == o2.Amount);
        }

        [TestMethod]
        public void SaveMemento_OriginalChanged_MementoStateNotChanged()
        {
            Order o = new Order();
            Order o2 = new Order();
            ArchivedOrder ao = new ArchivedOrder();
            o.Name = "ABC";
            o.Phone = "123456789";
            o.Address = "DEF 123";
            o.Amount = 10;

            ao.Memento = o.SaveMemento();
            o.Name = "XYZ";
            o2.RestoreMemento(ao.Memento);


            Assert.IsTrue(o.Name.Equals("XYZ") && o2.Name.Equals("ABC"));

        }

        [TestMethod]
        public void RestoreMemento_MementoValueUsed_PreviousStateRestored()
        {
            Order o = new Order();
            ArchivedOrder ao = new ArchivedOrder();
            o.Name = "ABC";
            o.Phone = "123456789";
            o.Address = "DEF 123";
            o.Amount = 10;

            ao.Memento = o.SaveMemento();
            o.Name = "XYZ";
            o.RestoreMemento(ao.Memento);

            Assert.AreEqual(o.Name, "ABC");
        }

    }
}
