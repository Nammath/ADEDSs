using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ADEDS.UnitTests
{
    [TestClass]
    public class FlyweightTests
    {
        [TestMethod]
        public void SpecificItem_MakeMultipleItemsWithSameModelItem_SameModelItemButDifferentSpecificItems()
        {
            ModelItem Puzzle1000 = new ModelItem {
                Name = "Puzzle, 1000 elementów",
                Model = "ver 1000 elementowa",
                Series = "Jeziora",
                Type = "Puzzle",
                Price = 29.95 };
            SpecificItem Puzzle1000x1 = new SpecificItem { SerialNumber = "ABC123XYZ", PlaceInStorage = "D13A" };
            SpecificItem Puzzle1000x2 = new SpecificItem { SerialNumber = "ABC124XYZ", PlaceInStorage = "D13A" };
            SpecificItem Puzzle1000x3 = new SpecificItem { SerialNumber = "ABC125XYZ", PlaceInStorage = "D13B" };

            Dictionary<ModelItem, SpecificItem> testStorage = new Dictionary<ModelItem, SpecificItem>();
            testStorage.Add(Puzzle1000, Puzzle1000x1);
            testStorage.Add(Puzzle1000, Puzzle1000x2);
            testStorage.Add(Puzzle1000, Puzzle1000x3);
            SpecificItem Test1 = testStorage[Puzzle1000];
            SpecificItem Test2 = testStorage[Puzzle1000];
        }

    }
}
