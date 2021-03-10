using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Product : IProduct
    {
        // baraye neshan dadane vijegiha az property estefade shodeh
        public int Id { get ; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }

        //raftar ba estefadeh az tavabeh moshakhas shodeh.
        public string GetBasicInfo()
        {
            string finalStr = Name +
                "\nAuthor: " + Author +
                "\nPrice: " + Price +
                "$ \nAvalable Count: " + AvailableCount;
            return finalStr;
        }
    }
}
