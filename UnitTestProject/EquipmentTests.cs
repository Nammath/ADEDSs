using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADEDS.UnitTests
{
    [TestClass]
    public class EquipmentTests
    {
        [TestMethod]
        public void SetParameters_CreateAndModifyVehicleItem_MileageLowerThanZeroOrNull()
        {
            Vehicle VehicleOne = new Vehicle();
            Vehicle VehicleTwo = new Vehicle();
            int? TestInt = null;

            Action ActionOne = () => VehicleOne.SetParameters("Test Vehicle", -1000, true);
            Action ActionTwo = () => VehicleTwo.SetParameters("Test Vehicle", (int)TestInt, true);
        }

        [TestMethod]
        public void SetParameters_CreateToolItem_MileageNotNull()
        {
            Tool Tool = new Tool();

            Action Action = () => Tool.SetParameters("Test Tool", 1000, true);

            Assert.ThrowsException<ArgumentException>(Action);
        }
    }
}
