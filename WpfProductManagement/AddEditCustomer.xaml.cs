using System;
using System.Windows;
using DataAccess;
using DataAccess.Models;

namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for AddEditCustomer.xaml
    /// </summary>
    public partial class AddEditCustomer : Window
    {
        private CustomerDataAccess customerDataAccess = new CustomerDataAccess();
        private Customer editingCustomer;
        private bool editMode = false;

        public AddEditCustomer(CustomerDataAccess cstDataAccess)
        {
            InitializeComponent();
            customerDataAccess = cstDataAccess;
        }

        public AddEditCustomer(CustomerDataAccess cstDataAccess, Customer cst)
        {
            InitializeComponent();
            customerDataAccess = cstDataAccess;
            editingCustomer = cst;
            editMode = true;
            tbFirstName_customer.Text = editingCustomer.FirstName;
            tbLastName_customer.Text = editingCustomer.LastName;
            tbPhoneNumber_customer.Text = editingCustomer.PhoneNumber.ToString();
            tbAddress_customer.Text = editingCustomer.Address;
        }

        private void btnCancel_customer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOk_customer_Click(object sender, RoutedEventArgs e)
        {

            if (editMode)
            {
                Customer cst = new Customer()
                {
                    Id = editingCustomer.Id,
                    FirstName = tbFirstName_customer.Text,
                    LastName = tbLastName_customer.Text,
                    PhoneNumber = Convert.ToUInt64(tbPhoneNumber_customer.Text),
                    Address = tbAddress_customer.Text,
                };
                customerDataAccess.EditCustomer(cst);
            }
            else
            {
                Customer cst = new Customer()
                {
                    Id = customerDataAccess.GetNexId(),
                    FirstName = tbFirstName_customer.Text,
                    LastName = tbLastName_customer.Text,
                    PhoneNumber = Convert.ToUInt64(tbPhoneNumber_customer.Text),
                    Address = tbAddress_customer.Text,
                };
                customerDataAccess.AddCustomer(cst);
                this.Close();
            }
        }
    }
}
