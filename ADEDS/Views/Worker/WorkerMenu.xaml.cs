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

namespace ADEDS.Views.Worker
{
    /// <summary>
    /// Logika interakcji dla klasy WorkerMenu.xaml
    /// </summary>
    public partial class WorkerMenu : Page
    {
        public WorkerMenu()
        {
            InitializeComponent();
            var user = MainWindow.loggedUser;
            loggedUserInfo.Content = "Logged as: " + user.firstName + " " + user.lastName + "\n" + "Position: " + user.GetType().ToString();
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow.loggedUser = null;
            this.NavigationService.Navigate(new LogIn());
        }
    }
}
