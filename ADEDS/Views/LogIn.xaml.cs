using ADEDS.Views.Client;
using ADEDS.Views.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADEDS.Views
{
    /// <summary>
    /// Logika interakcji dla klasy LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogInButton(object sender, RoutedEventArgs e)
        {
            if(loginTextBox.Text.Length == 0)
            {
                MessageBox.Show("Please enter your login");
                return;
            }
            if(passwordTextBox.Text.Length == 0)
            {
                MessageBox.Show("Please enter your password");
                return;
            }
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            foreach(var person in MainWindow.workerList)
            {
                if(person.login == login && person.password == password)
                {
                    MainWindow.loggedUser = person;
                    this.NavigationService.Navigate(new WorkerMenu());
                    return;
                }
            }
            foreach(var person in MainWindow.clientList)
            {
                if (person.login == login && person.password == password)
                {
                    MainWindow.loggedUser = person;
                    this.NavigationService.Navigate(new ClientMenu());
                    return;
                }
            }
            MessageBox.Show("User does not exist, or you provided wrong password, try again");


        }
    }
}
