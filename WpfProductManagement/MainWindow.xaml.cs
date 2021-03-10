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

namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePanel1.Visibility = Visibility.Visible;
            EmployeesPanel1.Visibility = Visibility.Collapsed;
            CustomersPanel1.Visibility = Visibility.Collapsed;
            ProductsPanel1.Visibility = Visibility.Collapsed;
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            HomePanel1.Visibility = Visibility.Collapsed;
            EmployeesPanel1.Visibility = Visibility.Visible;
            CustomersPanel1.Visibility = Visibility.Collapsed;
            ProductsPanel1.Visibility = Visibility.Collapsed;
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            HomePanel1.Visibility = Visibility.Collapsed;
            EmployeesPanel1.Visibility = Visibility.Collapsed;
            CustomersPanel1.Visibility = Visibility.Visible;
            ProductsPanel1.Visibility = Visibility.Collapsed;
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            HomePanel1.Visibility = Visibility.Collapsed;
            EmployeesPanel1.Visibility = Visibility.Collapsed;
            CustomersPanel1.Visibility = Visibility.Collapsed;
            ProductsPanel1.Visibility = Visibility.Visible;
        }
    }
}
