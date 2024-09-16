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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {

        }
    
        DbProductEntities db = new DbProductEntities();


        void CategoryList()
        {
            dataGridView1.DataSource = db.Categories.ToList();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Categories category = new Categories();
            category.Name = txtCategoryName.Text;
            db.Categories.Add(category);
            db.SaveChanges();
            CategoryList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var deletedItem = db.Categories.Find(id);
            db.Categories.Remove(deletedItem);
            db.SaveChanges();
            CategoryList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var updatedItem = db.Categories.Find(id);
            updatedItem.Name = txtCategoryName.Text;
            db.SaveChanges();
            CategoryList();
        }
    }
}
