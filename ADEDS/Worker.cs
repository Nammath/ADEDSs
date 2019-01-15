using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public abstract class Worker : Person
    {
        public int wage { get; set; }
        
        protected bool isDataAccessGranted;

        public bool IsDataAccessGranted
        {
            get { return isDataAccessGranted; }
            set { isDataAccessGranted = value; }
        }

        protected string workerPosition;

        public string WorkerPosition
        {
            get { return workerPosition; }
            set { workerPosition = value; }
        }

        public Worker()
        {
            this.wage = default(int);
            this.isDataAccessGranted = false;
            this.workerPosition = default(string);
        }

        public Worker(int wage, string firstName, string lastName, string login, string password)
        {
            this.wage = wage;
            this.firstName = firstName;
            this.lastName = lastName;
            this.login = login;
            this.password = password;
        }

        public abstract void wageRise();
        public abstract void dataAccess();
        public abstract void position();

    }

    public class Employee : Worker
    {
        public Employee(int wage, string firstName, string lastName, string login, string password) : base(wage, firstName, lastName, login, password) { }

        public override void wageRise() { }
        public override void dataAccess() { }
        public override void position() { }
    }

    public abstract class WorkerDecorator : Worker
    {
        protected Worker worker;

        public WorkerDecorator(Worker worker)
        {
            this.worker = worker;
        }

        public override void wageRise() { }
        public override void dataAccess() { }
        public override void position() { }
        
    }

    public class Manager : WorkerDecorator
    {
        public Manager(Worker worker): base(worker)
        {
            wageRise();
            dataAccess();
            position();
            firstName = worker.firstName;
            lastName = worker.lastName;
            login = worker.login;
            password = worker.password;

        }

        public override void wageRise()
        {
           wage = worker.wage*2;
        }
        public override void dataAccess()
        {
            IsDataAccessGranted = true;
        }
        public override void position()
        {
            WorkerPosition = "manager";
        }
    }

    public class ITSpecialist : WorkerDecorator
    {
        public ITSpecialist(Worker worker) : base(worker)
        {
            wageRise();
            dataAccess();
            position();
            firstName = worker.firstName;
            lastName = worker.lastName;
            login = worker.login;
            password = worker.password;
        }

        public override void wageRise()
        {
            wage = worker.wage * 3;
        }
        public override void dataAccess()
        {
            IsDataAccessGranted = true;
        }
        public override void position()
        {
            WorkerPosition = "it";
        }
    }
}
