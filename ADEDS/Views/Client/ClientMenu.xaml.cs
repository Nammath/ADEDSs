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

namespace ADEDS.Views.Client
{
    /// <summary>
    /// Logika interakcji dla klasy ClientMenu.xaml
    /// </summary>
    public partial class ClientMenu : Page
    {
        public ClientMenu()
        {
            InitializeComponent();
            var user = MainWindow.loggedUser;
            loggedUserInfo.Content = "Logged as: " + user.firstName + " " + user.lastName;
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow.loggedUser = null;
            this.NavigationService.Navigate(new LogIn());
        }
    }
}
