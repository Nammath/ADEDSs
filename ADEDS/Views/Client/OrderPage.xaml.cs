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
    /// Logika interakcji dla klasy OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        List<ModelItem> cart;
        string settlementType;
        public OrderPage(List<ModelItem> cart)
        {
            InitializeComponent();
            this.cart = cart;
            var user = MainWindow.loggedUser;
            loggedUserInfo.Content = "Logged as: " + user.firstName + " " + user.lastName;
            numberOfItemsTextBlock.Text = cart.Count.ToString();
            setType.SelectedIndex = 0;
            settlementType = setType.Text;
            

            double price = 0;
            foreach(var cartItem in cart)
            {
                price += cartItem.Price;
            }
            priceTextBlock.Text = price.ToString();

            listOfItems.ItemsSource = cart;
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow.loggedUser = null;
            this.NavigationService.Navigate(new LogIn());
        }
        private void goBackToShopping(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void order(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DetailsPage(settlementType, cart));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)setType.SelectedValue;
            settlementType = cbi.Content.ToString();
            
        }
    }
}
