using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Models;


namespace DataAccess
{
    public class EmployeeDataAccess
    {
            public List<Employee> Employees { get; set; } = new List<Employee>();

            public EmployeeDataAccess()
            {
                ReadEmployees();
            }

            private void ReadEmployees()
            {
                Employee emp1 = new Employee()
                {
                    Id = 1,
                    FirstName = "George",
                    LastName = "Orwell",
                    PhoneNumber = 12121212,
                    Address = "Tehran",
                    Department = Department.Production,
                    BaseSalary = 2500
                };
                Employee emp2 = new Employee()
                {
                    Id = 2,
                    FirstName = "Aldous",
                    LastName = "Huxley",
                    PhoneNumber = 51234556,
                    Address = "Tehran",
                    Department = Department.Management,
                    BaseSalary = 3500
                };
                Employees.Add(emp1);
                Employees.Add(emp2);
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
