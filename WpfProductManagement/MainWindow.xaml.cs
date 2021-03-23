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
using DataAccess;
using DataAccess.Models;

namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        CustomerDataAccess customerDataAccess = new CustomerDataAccess();
        ProductDataAcces productDataAcces = new ProductDataAcces();

        ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();
        ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();
        ObservableCollection<Product> Products=new ObservableCollection<Product>();

        public Employee currentEmployee { get; set; } = new Employee();
        public Customer currentCustomer { get; set; } = new Customer();
        public Product currentProduct { get; set; } = new Product();

        public MainWindow()
        {
            InitializeComponent();
            fillData();
            EmployeesGrid.ItemsSource = Employees;
            CustomersGrid.ItemsSource = Customers;
            ProductsGrid.ItemsSource = Products;
        }

        private void fillData()
        {
            Employees = employeeDataAccess.Employees;
            Customers = customerDataAccess.Customers;
            Products= productDataAcces.Products;
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

        private void EmployeesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(EmployeesGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesGrid.SelectedItem as Employee;
                EmployeeLabel.Content = currentEmployee.GetBasicInfo();
            }
        }

        private void CustomersGrid_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(CustomersGrid.SelectedIndex >= 0)
            {
                currentCustomer = CustomersGrid.SelectedItem as Customer;
                CustomerLabel.Content = currentCustomer.GetBasicInfo();
            }
        }

        private void ProductsGrid_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                currentProduct = ProductsGrid.SelectedItem as Product;
                ProductLabel.Content = currentProduct.GetBasicInfo();
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployee addWindow = new AddEditEmployee(employeeDataAccess);
            addWindow.ShowDialog();
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmployeesGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesGrid.SelectedItem as Employee;
                EmployeeLabel.Content = currentEmployee.GetBasicInfo();
            }

        }

        private void ProductsGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                currentProduct = ProductsGrid.SelectedItem as Product;
                ProductLabel.Content = currentProduct.GetBasicInfo();
            }

        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomersGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                currentCustomer = CustomersGrid.SelectedItem as Customer;
                CustomerLabel.Content = currentCustomer.GetBasicInfo();
            }
        }
    }
}
