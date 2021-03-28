using DataAccess;
using System;
using System.Windows;
using DataAccess.Models;

namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        private EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        private Employee editingEmployee;
        private bool isEdit = false;
        public AddEditEmployee(EmployeeDataAccess empDataAccess)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
        }

        public AddEditEmployee(EmployeeDataAccess empDataAccess, Employee emp)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
            editingEmployee = emp;
            isEdit = true;
            tbFirstName.Text = editingEmployee.FirstName;
            tbLastName.Text = editingEmployee.LastName;
            tbPhoneNumber.Text = editingEmployee.PhoneNumber.ToString();
            tbAddress.Text = editingEmployee.Address;
            tbSalary.Text = editingEmployee.BaseSalary.ToString();
            comboDepartment.SelectedIndex = (int)editingEmployee.Department;
        }

        private void tbCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbOk_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            isValid = CheckEmployeeValidity();

            if (isValid)
            {
                if (isEdit)
                {
                    Employee emp = new Employee()
                    {
                        Id = editingEmployee.Id,
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                        BaseSalary = Convert.ToDecimal(tbSalary.Text),
                        Department = (Department)comboDepartment.SelectedIndex,
                    };
                    employeeDataAccess.EditEmployee(emp);
                }
                else
                {
                    Employee emp = new Employee()
                    {
                        Id = employeeDataAccess.GetNexId(),
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                        BaseSalary = Convert.ToDecimal(tbSalary.Text),
                        Department = (Department)comboDepartment.SelectedIndex,
                    };
                    employeeDataAccess.AddEmployee(emp);
                    this.Close();
                }
            }
        }

        private bool CheckEmployeeValidity()
        {
            bool isValid = true;
            string firstName = tbFirstName.Text.Trim().ToLower();
            string lastName = tbLastName.Text.Trim().ToLower();
            string phoneNumber = tbPhoneNumber.Text.Trim().ToLower();
            string address = tbAddress.Text.Trim().ToLower();
            int department = comboDepartment.SelectedIndex;
            string baseSalary = tbSalary.Text.Trim().ToLower();

            if(string.IsNullOrEmpty(firstName))
            {
                isValid = false;
                lblError.Content = "**First name is invalid!";
            }
            else if (string.IsNullOrEmpty(lastName))
            {
                isValid = false;
                lblError.Content = "**Last name is invalid!";
            }
            else if (!UInt64.TryParse(phoneNumber, out ulong p))
            {
                isValid = false;
                MessageBox.Show("Phone number is invalid!");
            }
            else if(address.Contains("china"))
            {
                isValid = false;
                MessageBox.Show("China is not accepted!");
            }
            else if (department < 0)
            {
                isValid = false;
                MessageBox.Show("Please select a Department!");
            }
            else if (!decimal.TryParse(baseSalary, out decimal b) || b > 5000)
            {
                isValid = false;
                lblError.Content = "**Salary is incorrect";
            }
            else
            {
                lblError.Content = "";
            }
            return isValid;
        }

        private void tbPhoneNumber_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string phoneNumber = tbPhoneNumber.Text.Trim().ToLower();
            if (!UInt64.TryParse(phoneNumber, out ulong p))
            {
                lblError.Content = "**Phone number is invalid!";
            }
            else
            {
                lblError.Content = "";
            }
        }
    }
}
