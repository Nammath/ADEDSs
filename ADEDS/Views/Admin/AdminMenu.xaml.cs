using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ADEDS.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Page
    {
        public List<ADEDS.Worker> workerList { get; set; }
        public AdminMenu()
        {
            workerList = MainWindow.workerList;
            workerList.Sort((x, y) => string.Compare(x.lastName, y.lastName));
            InitializeComponent();

            this.DataContext = this;

        }

        private void ChangeManager(object sender, RoutedEventArgs e)
        {
            ADEDS.Worker a = (ADEDS.Worker)lvWorkers.SelectedItem;
            if (a != null)
                if (a.is_manager.Equals("X"))
            {
                workerList.Remove(a);
                workerList.Add(new Manager(a));
                workerList.Sort((x, y) => string.Compare(x.lastName, y.lastName));
                lvWorkers.Items.Refresh();
            }
        }

        private void ChangeITSpecialist(object sender, RoutedEventArgs e)
        {
            ADEDS.Worker a = (ADEDS.Worker)lvWorkers.SelectedItem;
            if(a != null)
                if (a.is_IT_spec.Equals("X"))
            {
                workerList.Remove(a);
                workerList.Add(new ITSpecialist(a));
                workerList.Sort((x, y) => string.Compare(x.lastName, y.lastName));
                lvWorkers.Items.Refresh();
            }
        }

        private void ChangeWage(object sender, RoutedEventArgs e)
        {
            ADEDS.Worker a = (ADEDS.Worker)lvWorkers.SelectedItem;
            if(a!= null)
                a.wageChange(Int32.Parse(tbWage.Text));
            lvWorkers.Items.Refresh();
        }

        private void Unemploy(object sender, RoutedEventArgs e)
        {
            if(lvWorkers.SelectedItem != null)
                workerList.Remove((ADEDS.Worker)lvWorkers.SelectedItem);
            lvWorkers.Items.Refresh();
        }

        private void LvWorkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ADEDS.Worker a = (ADEDS.Worker)lvWorkers.SelectedItem;
            if (a == null) tbWage.Text = "";
            else tbWage.Text = a.wage.ToString();
        }
    }
}
