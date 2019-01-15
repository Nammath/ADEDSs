using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADEDS.UnitTests
{
    [TestClass]
    public class IteratorTests
    {
        [TestMethod]
        public void HasNext_CheckForNextElement_NoElements()
        {
            List<Worker> ListOfWorkers = new List<Worker>();

            Iterator Iterator = new Iterator(ListOfWorkers);

            Assert.IsFalse(Iterator.HasNext());
        }
        [TestMethod]
        public void HasNext_CheckForNextITSpecialistElement_OnlyManagerElements()
        {
            List<Worker> ListOfWorkers = new List<Worker>();
            ListOfWorkers.Add(new Manager(new Employee(1000, "Jan", "Kowalski", "test", "test")));
            ListOfWorkers.Add(new Manager(new Employee(2000, "Jacek", "Placek", "login", "password")));

            ITSpecialistIterator Iterator = new ITSpecialistIterator(ListOfWorkers);

            Assert.IsFalse(Iterator.HasNext());
        }
        [TestMethod]
        public void HasNext_CheckForNextManagerElement_OnlyITSpecialistElements()
        {
            List<Worker> ListOfWorkers = new List<Worker>();
            ListOfWorkers.Add(new ITSpecialist(new Employee(1000, "Jan", "Kowalski", "test", "test")));
            ListOfWorkers.Add(new ITSpecialist(new Employee(2000, "Jacek", "Placek", "login", "password")));

            ManagerIterator Iterator = new ManagerIterator(ListOfWorkers);

            Assert.IsFalse(Iterator.HasNext());
        }

        [TestMethod]
        public void Next_GetNextElement_NoElements()
        {
            List<Worker> ListOfWorkers = new List<Worker>();

            Iterator Iterator = new Iterator(ListOfWorkers);
            Worker ReturnedWorker;
            Action Action = () => { ReturnedWorker = Iterator.Next(); };

            Assert.ThrowsException<ArgumentOutOfRangeException>(Action);
        }
    }
}
