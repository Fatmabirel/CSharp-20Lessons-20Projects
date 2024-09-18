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
    public partial class FrmMovie : Form
    {
        public FrmMovie()
        {
            InitializeComponent();
        }

        MovieContext context = new MovieContext();
        void CategoryList()
        {
            var values = context.Categories.ToList();
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
            cmbCategory.DataSource = values;
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = context.Movies.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmMovie_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie();
            movie.Title = txtName.Text;
            movie.Description = txtDescription.Text;
            movie.Duration = int.Parse(txtDuration.Text);
            movie.CreatedDate = DateTime.Parse(mtbDate.Text);
            movie.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            context.Movies.Add(movie);
            context.SaveChanges();
            MessageBox.Show("İşlem başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var value = context.Movies.Find(id);
            context.Movies.Remove(value);
            context.SaveChanges();
            MessageBox.Show("İşlem başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var value = context.Movies.Find(id);
            value.Title = txtName.Text;
            value.Description = txtDescription.Text;
            value.Duration = int.Parse(txtDuration.Text);
            value.CreatedDate = DateTime.Parse(mtbDate.Text);
            context.SaveChanges();
            MessageBox.Show("İşlem başarılı");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = context.Movies
                        .Where(x => x.Title.Contains(txtName.Text))
                        .ToList();
            dataGridView1.DataSource = values;
        }

        private void btnMovieWithCategory_Click(object sender, EventArgs e)
        {
            var values = context.Movies.Join(context.Categories,
                movie => movie.CategoryId,
                category => category.Id,
                (movie, category) => new
                {
                    Id = movie.Id,
                    MovieTitle = movie.Title,
                    Description = movie.Description,
                    Duration = movie.Duration,
                    CreatedDate = movie.CreatedDate,
                    CategoryName = category.Name,
                }).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
