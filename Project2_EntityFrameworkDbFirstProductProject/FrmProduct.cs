using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2_EntityFrameworkDbFirstProductProject
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        DbProductEntities db = new DbProductEntities();
        void ProductList()
        {
            dataGridView1.DataSource = db.Products.ToList();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            ProductList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Products product = new Products();
            product.Name = txtProductName.Text;
            product.Price = decimal.Parse(txtProductPrice.Text);
            product.Stock = int.Parse(txtProductStock.Text);
            product.CategoryId = int.Parse(cmbProductCategory.SelectedValue.ToString());
            db.Products.Add(product);
            db.SaveChanges();
            ProductList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var deletedItem = db.Products.Find(id);
            db.Products.Remove(deletedItem);
            db.SaveChanges();
            ProductList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var updatedItem = db.Products.Find(id);
            updatedItem.Name = txtProductName.Text;
            updatedItem.Price = int.Parse(txtProductPrice.Text);
            updatedItem.Stock = int.Parse(txtProductStock.Text);
            updatedItem.CategoryId = int.Parse(cmbProductCategory.SelectedValue.ToString());
            db.SaveChanges();
            ProductList();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            cmbProductCategory.DisplayMember = "Name";
            cmbProductCategory.ValueMember = "Id";
            cmbProductCategory.DataSource = values;
        }

        private void btnProductListWithCategory_Click(object sender, EventArgs e)
        {
            var values = db.Products.Join(db.Categories,
                product => product.CategoryId,
                category => category.Id,
                (product, category) => new
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    ProductStock = product.Stock,
                    CategoryId = category.Id,
                    CategoryName = category.Name,
                }
                ).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = db.Products.Where(p => p.Name == txtProductName.Text).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
