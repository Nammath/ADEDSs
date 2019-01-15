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
        List<ModelItem> specificItemList;
        List<ModelItem> cart;
        public ClientMenu()
        {
            cart = new List<ModelItem>();
            InitializeComponent();
            var user = MainWindow.loggedUser;
            loggedUserInfo.Content = "Logged as: " + user.firstName + " " + user.lastName;

            specificItemList = MainWindow.storage.getListOfModelItems();
            listOfItems.ItemsSource = specificItemList;
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow.loggedUser = null;
            this.NavigationService.Navigate(new LogIn());
        }

        private void addToCart(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            int index = listOfItems.Items.IndexOf(item);

            foreach(var modelItem in cart)
            {
                if((ModelItem)modelItem == item)
                {
                    MessageBox.Show("Item already in shoping cart!");
                    return;
                }
            }
            ListViewItem dataItem = (ListViewItem)listOfItems.ItemContainerGenerator.ContainerFromIndex(index);
            Button btn = FindByName("deleteButton", dataItem) as Button;
            btn.Visibility = Visibility.Visible;
            cart.Add((ModelItem)item);
            cartButton.Content = "Cart (" + cart.Count.ToString() + ")";
        }

        private FrameworkElement FindByName(string name, FrameworkElement root)
        {
            Stack<FrameworkElement> tree = new Stack<FrameworkElement>();
            tree.Push(root);

            while (tree.Count > 0)
            {
                FrameworkElement current = tree.Pop();
                if (current.Name == name)
                    return current;

                int count = VisualTreeHelper.GetChildrenCount(current);
                for (int i = 0; i < count; ++i)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(current, i);
                    if (child is FrameworkElement)
                        tree.Push((FrameworkElement)child);
                }
            }

            return null;
        }

        private void deleteFromCart(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            
            for (int i = 0; i < cart.Count; i++)
            {
                ModelItem temp = cart[i];
                if(temp == item)
                {
                    cart.Remove(temp);
                    break;
                }
            }
            
            cartButton.Content = "Cart (" + cart.Count.ToString() + ")";
            (sender as Button).Visibility = Visibility.Hidden;
        }

        private void goToCart(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OrderPage(cart));
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(cart.Count > 0) { e.CanExecute = true; }
            else { e.CanExecute = false; }
        }
    }
}
