using ADEDS.Views;
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

namespace ADEDS
{
  
    public partial class MainWindow : Window
    {
        public static List<Worker> workerList = new List<Worker>();
        public static List<Client> clientList = new List<Client>();
        public static Person loggedUser;

        public MainWindow()
        {
            InitializeComponent();
            
            workerList.Add(new Manager(new Employee(3000, "Jacek", "Nowak", "Jacek", "haslo")));
            workerList.Add(new ITSpecialist(new Employee(2500, "Daniel", "Kowalski", "Daniel", "haslo")));
            workerList.Add(new Employee(2000, "Szymon", "Kowalczyk", "Szymon", "haslo"));

            clientList.Add(new Client("Jan", "Lewandowski", "Janek", "haslo"));
            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LogIn());
        }
    }
}
