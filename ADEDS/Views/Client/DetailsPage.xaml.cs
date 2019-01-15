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
    /// Logika interakcji dla klasy DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        string settlementType;
        Settlement settlement;
        List<ModelItem> cart;
        public DetailsPage(string type, List<ModelItem> modelItem)
        {
            InitializeComponent();
            settlementType = type;
            settlement = new Settlement(settlementType);
            cart = modelItem;
            setType.SelectedIndex = 0;

            var user = MainWindow.loggedUser;
            loggedUserInfo.Content = "Logged as: " + user.firstName + " " + user.lastName;

        }
        

        private void apply(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string phone = phoneTextBox.Text;
            string address = addressTextBox.Text;
            foreach(var item in cart)
            {
                Order order = new Order();
                order.Name = name;
                order.Phone = phone;
                order.Address = address;
                order.Amount = 1;
                order.Item = item;
                MainWindow.storage.addOrder(order);
            }
            settlement.printSettlement(cart);
        }

        private void back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow.loggedUser = null;
            this.NavigationService.Navigate(new LogIn());
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(nameTextBox.Text != "" && phoneTextBox.Text != "" && addressTextBox.Text != "") { e.CanExecute = true; }
            else { e.CanExecute = false; }
        }

        private void setType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            settlement.changeType();
        }
    }
}
