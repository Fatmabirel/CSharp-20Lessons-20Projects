using Dapper;
using Project5_DapperProductProject.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project5_DapperProductProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Server=DESKTOP-Q270QVE\\SQLEXPRESS; initial catalog=northwind; integrated security= true");
        private async void btnCategoryList_Click(object sender, EventArgs e)
        {
            string query = "Select * from Categories";
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            dataGridView1.DataSource = values;
        }

        private async void btnCreateCategory_Click(object sender, EventArgs e)
        {
            string query = "insert into categories (CategoryName,Description) Values (@p1,@p2)";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", txtCategoryName.Text);
            parameters.Add("@p2", txtCategoryDescription.Text);
            await connection.ExecuteAsync(query, parameters);

        }

        private async void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            string query = "Delete From Categories Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId",txtCategoryId.Text);
            await connection.ExecuteAsync(query, parameters);
        }

        private async void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string query = "Update Categories Set CategoryName=@categoryName,Description=@categoryDescription Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", txtCategoryId.Text);
            parameters.Add("@categoryName", txtCategoryName.Text);
            parameters.Add("@categoryDescription", txtCategoryDescription.Text);
            await connection.ExecuteAsync(query, parameters);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //Kategori sayısı
            string query = "Select Count(*) from Categories";          
            var categoryCount = await connection.ExecuteScalarAsync<int>(query);
            lblCategoryCount.Text = "Toplam Kategori Sayısı: " + categoryCount;

            //Ürün sayısı
            string query2 = "Select Count(*) from Products";
            var productCount = await connection.ExecuteScalarAsync<int>(query2);
            lblProductCount.Text = "Toplam Ürün Sayısı: " + productCount;

            //Ortalama ürün stok sayısı
            string query3 = "Select Avg(UnitsInStock) from Products";
            var avgProductStock = await connection.ExecuteScalarAsync<int>(query3);
            lblAvgProductStock.Text = "Ortalama Ürün Stok Sayısı: " + avgProductStock;

            //Deniz ürünleri toplam fiyatı 
            string query4 = "Select Sum(UnitPrice) from Products Where CategoryId=(Select CategoryId From Categories Where CategoryName='SeaFood')";
            var totalSeafoodPrice = await connection.ExecuteScalarAsync<decimal>(query4);
            lblSeaFoodProductTotalPrice.Text = "Deniz Ürünleri Toplam Fiyatı: " + totalSeafoodPrice;
        }

    }
}
