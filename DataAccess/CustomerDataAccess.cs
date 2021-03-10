using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Models;

namespace DataAccess
{
    public class CustomerDataAccess
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public CustomerDataAccess()
        {
            ReadCustomers();
        }

        private void ReadCustomers()
        {
            Customer cst1 = new Customer()
            {
                Id = 1,
                FirstName = "Nick",
                LastName = "Nouri",
                PhoneNumber = 12121212,
                Address = "Denmark"
            };
            Customer cst2 = new Customer()
            {
                Id = 2,
                FirstName = "Amer",
                LastName = "Nilsen",
                PhoneNumber = 51234556,
                Address = "Italy"
            };
            Customers.Add(cst1);
            Customers.Add(cst2);
        }

        public void AddCustomer(Customer cst)
        {
            Customers.Add(cst);
        }

        public void RemoveCustomer(int id)
        {
            Customer temp = Customers.First(x => x.Id == id);
            Customers.Remove(temp);
        }

        public void EditCustomer(Customer cst)
        {
            Customer temp = Customers.First(x => x.Id == cst.Id);
            int index = Customers.IndexOf(temp);
            Customers[index] = cst;
        }

        public int GetNexId()
        {
            int index = Customers.Any() ? Customers.Max(x => x.Id) + 1 : 1;
            return index;
        }
    }
}
