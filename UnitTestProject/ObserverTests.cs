using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADEDS.UnitTests
{
    [TestClass]
    public class ObserverTests
    {
        [TestMethod]
        public void Attach_NewObserverRegisters_ObserverIsOnTheList()
        {
            Delivery d = new Delivery(new Order());
            DeliveryDisplay dd = new DeliveryDisplay();

            d.Attach(dd);

            Assert.IsTrue(d.observersList.Contains(dd));
        }

        [TestMethod]
        public void Detach_ObserverUnregisters_ObserverIsNotOnTheList()
        {
            Delivery d = new Delivery(new Order());
            DeliveryDisplay dd = new DeliveryDisplay();

            d.Attach(dd);
            d.Detach(dd);

            Assert.IsFalse(d.observersList.Contains(dd));
        }

        [TestMethod]
        public void Update_DeliveryIsUpdated_ObserverHasUpdatedVersion()
        {
            Delivery d = new Delivery(new Order());
            DeliveryDisplay dd = new DeliveryDisplay();

            d.Attach(dd);
            d.Finished();

            Assert.IsTrue(dd.deliveryList[0].IsFinished());
        }

        [TestMethod]
        public void Update_DeliveryIsUpdatedMultipleTimes_NumberOfUpdatesIsCorrect()
        {
            Delivery d = new Delivery(new Order());
            DeliveryDisplay dd = new DeliveryDisplay();

            d.Attach(dd);
            d.Finished();
            d.NotFinished();
            d.Finished();

            Assert.AreEqual(dd.numberOfUpdates, 3);
        }
        
    }   
}
