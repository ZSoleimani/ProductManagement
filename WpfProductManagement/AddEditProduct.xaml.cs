using System;
using DataAccess;
using System.Windows;
using DataAccess.Models;

namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Window
    {
        private ProductDataAccess productDataAccess = new ProductDataAccess();
        private Product editingProduct;
        private bool editIt = false;
        private object productDataAccess1;

        public AddEditProduct(object productDataAccess1)
        {
            this.productDataAccess1 = productDataAccess1;
        }

        public AddEditProduct(ProductDataAcces prtDataAccess, Product prt)
        {
            InitializeComponent();
            productDataAccess = prtDataAccess;
            editingProduct = prt;
            editIt = true;
            tbName.Text = editingProduct.Name;
            tbAuthor.Text = editingProduct.Author;
            tbPrice.Text = editingProduct.Price.ToString();
            tbAvailableCount.Text = editingProduct.AvailableCount.ToString();
        }
        
        private void btnCancel_Product_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOk_Product_Click(object sender, RoutedEventArgs e)
        {
            if (editIt)
            {
                Product prt = new Product()
                {
                    Id = editingProduct.Id,
                    Name = tbName.Text,
                    Author = tbAuthor.Text,
                    Price = Convert.ToUInt64(tbPrice.Text),
                    AvailableCount = (int)Convert.ToUInt64(tbAvailableCount.Text),
                };
                productDataAccess.EditProduct(prt);
            }
            else
            {
                Product prt = new Product()
                {
                    Id = productDataAccess.GetNexId(),
                    Name = tbName.Text,
                    Author = tbAuthor.Text,
                    Price = Convert.ToUInt64(tbPrice.Text),
                    AvailableCount = (int)Convert.ToDecimal(tbAvailableCount.Text),
                };
                productDataAccess.AddProduct(prt);
                this.Close();
            }
        }
    }
}
