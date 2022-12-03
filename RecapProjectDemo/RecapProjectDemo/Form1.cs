using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapProjectDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListProducts();
            ListCategories();
        }

        private void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource = context.Products.ToList();
            }
        }


        private void ListCategories()
        {
            using(NorthwindContext context=new NorthwindContext())
            {
                cbxCategory.DataSource=context.categories.ToList();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryId";
            }
        }

        private void ListProductsbyCategories(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource=context.Products.Where(p=>p.CategoryId==categoryId).ToList();
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                try
                {
                    ListProductsbyCategories(Convert.ToInt32(cbxCategory.SelectedValue));
                }
                catch 
                {

                    
                }
            }
        }

        private void ListProductsbyNames(string key)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource=context.Products.Where(p=>p.ProductName.ToLower().Contains(key.ToLower())).ToList();
            }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {                
            string key=tbxName.Text;
            if (string.IsNullOrEmpty(key))
            {
                ListProducts();
            }
            else
            {
                ListProductsbyNames(tbxName.Text);
            }


        }
    }
}
