using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class Client : Person
    {
        private Order clientOrder;
        public Client(string firstName, string lastName, string login, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.login = login;
            this.password = password;
        }
    }
}
