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

        public AddEditProduct(ProductDataAcces productDataAccess1)
        {
            InitializeComponent();
            ProductDataAccess productDataAccess2 = productDataAccess;
#pragma warning restore CS1717 // Assignment made to same variable
        }

        public AddEditProduct(object productDataAccess1)
        {
            this.productDataAccess1 = productDataAccess1;
        }

        public AddEditProduct(ProductDataAcces productDataAcces, Product product)
        {
            InitializeComponent();
            productDataAccess = productDataAcces;
            tbName.Text = product.Name;
            tbAuthor.Text = product.Author;
            tbAvailableCount.Text = product.AvailableCount.ToString();
            tbPrice.Text = product.Price.ToString();
            editIt = true;
            editingProduct = product;
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
                    AvailableCount = (int)Convert.ToUInt64(tbAvailableCount.Text),
                    Price = Convert.ToUInt64(tbPrice.Text),
 
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
                    AvailableCount = (int)Convert.ToDecimal(tbAvailableCount.Text),
                    Price = Convert.ToDecimal(tbPrice.Text),
                };
                productDataAccess.AddProduct(prt);
                this.Close();
            }
        }
    }
}
