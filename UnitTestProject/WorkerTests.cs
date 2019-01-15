using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADEDS.UnitTests
{
    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        public void Constructor_CreatingDefault_ReturnsTrue()
        {
            var employee = new Employee(1000, "Jacek", "Nowak", "Jacek", "haslo");

            bool isAccessGranted = employee.IsDataAccessGranted;
            string position = employee.WorkerPosition;

            bool result;

            if (isAccessGranted == false && position == default(string))
                result = true;
            else
                result = false;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Constructor_CreatingObject_ReturnsTrue()
        {
            var employee = new Employee(1000, "Jacek", "Nowak", "Jacek", "haslo");

            string firstName = employee.firstName;
            string lastname = employee.lastName;

            bool result;
            if (firstName == "Jacek" && lastname == "Nowak")
                result = true;
            else
                result = false;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ManagerConstructor_IsManagerObjectCreating_ReturnsTrue()
        {
            var managerobj = new Manager(new Employee(1000, "Jacek", "Nowak", "Jacek", "haslo"));

            bool result;
            if (managerobj.GetType() == typeof(ADEDS.Manager))
                result = true;
            else
                result = false;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ITConstructor_IsITSpecialistObjectCreating_ReturnsTrue()
        {
            Worker worker = new ITSpecialist(new Employee(1000, "Jacek", "Nowak", "Jacek", "haslo"));

            bool result;

            if (worker.GetType() == typeof(ADEDS.ITSpecialist))
                result = true;
            else
                result = false;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ManagerAttributes_DecoratingManager_ReturnsDecorateManager()
        {
            var managerobj = new Manager(new Employee(1000, "Jacek", "Nowak", "Jacek", "haslo"));
            

            bool result;
            if (managerobj.wage == 2000 && managerobj.IsDataAccessGranted == true && managerobj.WorkerPosition == "manager")
                result = true;
            else
                result = false;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ITSpecialistAttributes_DecoratingITSpecialist_ReturnsDecorateManager()
        {
            var itobject = new ITSpecialist(new Employee(1000, "Jacek", "Nowak", "Jacek", "haslo"));
            
            bool result;
            if (itobject.wage == 3000 && itobject.IsDataAccessGranted == true && itobject.WorkerPosition == "it")
                result = true;
            else
                result = false;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ManagerLogin_DoesManagerHasLogin_ReturnsLogin()
        {
            var managerobj = new Manager(new Employee(1000, "Jacek", "Nowak", "Jacek", "haslo"));

            string login = managerobj.login;
            
            Assert.AreEqual(login, "Jacek");
        }
    }
}
