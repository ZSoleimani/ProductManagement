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
}
