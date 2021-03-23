using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess.Models;

namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        private EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        public AddEditEmployee(EmployeeDataAccess empDataAccess)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
        }

        private void tbCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbOk_Click(object sender, RoutedEventArgs e)
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
