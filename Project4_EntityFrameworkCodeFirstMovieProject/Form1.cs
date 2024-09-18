using Project4_EntityFrameworkCodeFirstMovieProject.DAL.Context;
using Project4_EntityFrameworkCodeFirstMovieProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4_EntityFrameworkCodeFirstMovieProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MovieContext context = new MovieContext();
    
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = context.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name = txtName.Text;
            context.Categories.Add(category);
            context.SaveChanges();
            MessageBox.Show("İşlem başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var value = context.Categories.Find(id);
            value.Name = txtName.Text;
            context.SaveChanges();
            MessageBox.Show("İşlem başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            MessageBox.Show("İşlem başarılı");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = context.Categories
                        .Where(x => x.Name.Contains(txtName.Text))
                        .ToList();
            dataGridView1.DataSource = values;
        }
    }
}
