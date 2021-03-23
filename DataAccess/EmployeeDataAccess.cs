using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using DataAccess.Models;


namespace DataAccess
{
    public class EmployeeDataAccess
    {
            public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

            public EmployeeDataAccess()
            {
                ReadEmployees();
            }

            private void ReadEmployees()
            {
                Employee emp1 = new Employee()
                {
                    Id = 1,
                    FirstName = "Sulaiman",
                    LastName = "Kasas",
                    PhoneNumber = 42321772,
                    Address = "Danmark",
                    Department = Department.Sales,
                    BaseSalary = 2500
                };
                Employee emp2 = new Employee()
                {
                    Id = 2,
                    FirstName = "Amer",
                    LastName = "Biro",
                    PhoneNumber = 42492297,
                    Address = "Danmark",
                    Department = Department.Management,
                    BaseSalary = 3500
                };
                Employee emp3 = new Employee()
                {
                Id = 3,
                FirstName = "Zahra",
                LastName = "Soleimani",
                PhoneNumber = 71658952,
                Address = "Danmark",
                Department = Department.Advertisement,
                BaseSalary = 2500
                };
                Employees.Add(emp1);
                Employees.Add(emp2);
                Employees.Add(emp3);
            }

            public void AddEmployee(Employee emp)
            {
                Employees.Add(emp);
            }

            public void RemoveProduct(int id)
            {
                Employee temp = Employees.First(x => x.Id == id);
                Employees.Remove(temp);
            }

            public void EditEmployee(Employee emp)
            {
                Employee temp = Employees.First(x => x.Id == emp.Id);
                int index = Employees.IndexOf(temp);
                Employees[index] = emp;
            }

            public int GetNexId()
            {
                int index = Employees.Any() ? Employees.Max(x => x.Id) + 1 : 1;
                return index;
            }
        }
    }
