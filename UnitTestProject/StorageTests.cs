using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADEDS.UnitTests
{
    [TestClass]
    public class StorageTests
    {
        [TestMethod]
        public void getStorageInstance_RequestingInstance_ReturnsStorage()
        {
            var storage = Storage.getStorageInstance();

            var result = storage is Storage;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void getStorageInstance_RequestingMultipleInstances_ReturnsStorage()
        {
            var firstStorage = Storage.getStorageInstance();
            var secondStorage = Storage.getStorageInstance();

            var result = ReferenceEquals(firstStorage, secondStorage);

            Assert.IsTrue(result);
        }
    }
}
