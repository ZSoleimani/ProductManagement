using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Employee : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
        public decimal BaseSalary { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public ulong Price { get; set; }
        public decimal AvailableCount { get; set; }

        public string GetBasicInfo()
        {
            string finalStr = FirstName + " " + LastName +
                "\nTell: " + PhoneNumber +
                "\nAddress: " + Address +
                "\nDepartment: " + Department +
                "\nBase Salary: " + BaseSalary;
            return finalStr;
        }
    }

    public enum Department
    {
        Production,
        Sales,
        Advertisement,
        Management,
    }
}
