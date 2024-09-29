using Project9_MongoDbOrderProject.Entities;
using Project9_MongoDbOrderProject.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Project9_MongoDbOrderProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OrderOperation orderOperation = new OrderOperation();
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var order = new Order
            {
                City = txtCity.Text,
                CustomerName = txtCustomer.Text,
                District = txtDistrict.Text,
                TotalPrice = decimal.Parse(txtTotalPrice.Text)
            };
            orderOperation.AddOrder(order);
            MessageBox.Show("Ekleme işlemi yapıldı");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Order> orders = orderOperation.GetOrders();
            dataGridView1.DataSource = orders;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string orderId = txtId.Text;
            orderOperation.DeleteOrder(orderId);
            MessageBox.Show("Silme işlemi tamamlandı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string orderId = txtId.Text;
            var updateOrder = new Order
            {
                Id = orderId,
                City = txtCity.Text,
                CustomerName = txtCustomer.Text,
                District = txtDistrict.Text,
                TotalPrice = decimal.Parse(txtTotalPrice.Text)
            };
            orderOperation.UpdateOrder(updateOrder);
            MessageBox.Show("Güncelleme işlemi tamamlandı");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            string orderId = txtId.Text;
            Order orders = orderOperation.GetOrderById(orderId);
            dataGridView1.DataSource = new List<Order> { orders };
        }
    }
}
