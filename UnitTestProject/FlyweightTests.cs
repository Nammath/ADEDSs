using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ADEDS.UnitTests
{
    [TestClass]
    public class FlyweightTests
    {
        [TestMethod]
        public void GetUnsoldItem_RequestItem_ItemIsFlaggedAsSold()
        {
            Storage s = Storage.getStorageInstance();
            ModelItem Puzzle1000 = new ModelItem
            {
                Name = "Puzzle, 1000 elementów",
                Model = "ver 1000 elementowa",
                Series = "Jeziora",
                Type = "Puzzle",
                Price = 29.95
            };
            SpecificItem Puzzle1000x1 = new SpecificItem { SerialNumber = "ABC123XYZ", PlaceInStorage = "D13A" };
            s.AddItem(Puzzle1000x1, Puzzle1000);

            SpecificItem test = s.GetUnsoldItem(Puzzle1000);

            Assert.IsTrue(test.IsSold());
        }

        [TestMethod]
        public void GetUnsoldItem_NoUnsoldItems_ReturnsNull()
        {
            Storage s = Storage.getStorageInstance();
            ModelItem Puzzle1000 = new ModelItem
            {
                Name = "Puzzle, 1000 elementów",
                Model = "ver 1000 elementowa",
                Series = "Jeziora",
                Type = "Puzzle",
                Price = 29.95
            };
            SpecificItem Puzzle1000x1 = new SpecificItem { SerialNumber = "ABC123XYZ", PlaceInStorage = "D13A" };
            SpecificItem Puzzle1000x2 = new SpecificItem { SerialNumber = "ABC124XYZ", PlaceInStorage = "D13A" };
            SpecificItem Puzzle1000x3 = new SpecificItem { SerialNumber = "ABC125XYZ", PlaceInStorage = "D13B" };
            s.AddItem(Puzzle1000x1, Puzzle1000);
            s.AddItem(Puzzle1000x2, Puzzle1000);
            s.AddItem(Puzzle1000x3, Puzzle1000);

            SpecificItem test = s.GetUnsoldItem(Puzzle1000);
            test = s.GetUnsoldItem(Puzzle1000);
            test = s.GetUnsoldItem(Puzzle1000);
            test = s.GetUnsoldItem(Puzzle1000);

            Assert.IsNull(test);
        }

        [TestMethod]
        public void GetUnsoldItem_TwoItemsRequested_TwoDifferentItemsRecieved()
        {
            Storage s = Storage.getStorageInstance();
            ModelItem Puzzle1000 = new ModelItem
            {
                Name = "Puzzle, 1000 elementów",
                Model = "ver 1000 elementowa",
                Series = "Jeziora",
                Type = "Puzzle",
                Price = 29.95
            };
            SpecificItem Puzzle1000x1 = new SpecificItem { SerialNumber = "ABC123XYZ", PlaceInStorage = "D13A" };
            SpecificItem Puzzle1000x2 = new SpecificItem { SerialNumber = "ABC124XYZ", PlaceInStorage = "D13A" };
            SpecificItem Puzzle1000x3 = new SpecificItem { SerialNumber = "ABC125XYZ", PlaceInStorage = "D13B" };
            s.AddItem(Puzzle1000x1, Puzzle1000);
            s.AddItem(Puzzle1000x2, Puzzle1000);
            s.AddItem(Puzzle1000x3, Puzzle1000);

            SpecificItem test = s.GetUnsoldItem(Puzzle1000);
            SpecificItem test2 = s.GetUnsoldItem(Puzzle1000);

            Assert.AreNotEqual(test.SerialNumber, test2.SerialNumber);
        }

    }
}
