using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project10_PostgreSQLToDoListProject
{
    public partial class FrmToDoList : Form
    {
        public FrmToDoList()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localHost;port=5432;Database=DbToDoList;user ID=postgres; Password=123";

        void ToDoList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * From todolists order by id";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        void CategoryList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * From categories order by id";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
            cmbCategory.DataSource = dataTable;
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToDoList();
            CategoryList();
        }

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            FrmCategory frmCategory = new FrmCategory();
            frmCategory.Show();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            ToDoList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            string title = txtTitle.Text;
            string priority = txtPriority.Text;
            string description = txtDescription.Text;

            // Varsayılan değer
            bool status = rdbCompleted.Checked; // Eğer rdbCompleted seçilmişse true, değilse false olacak

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO ToDoLists (title, description, status, priority, categoryId) VALUES (@title, @description, @status, @priority, @categoryId)";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@status", status); // Boolean değerini burada gönderiyoruz
                    command.Parameters.AddWithValue("@priority", priority);
                    command.Parameters.AddWithValue("@categoryId", categoryId);
                    command.ExecuteNonQuery(); // Sorguyu çalıştır
                    MessageBox.Show("Yapılacak İş eklendi");
                    ToDoList(); // Güncellenmiş listeyi yenile
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Delete From todolists Where id = @id";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                MessageBox.Show("Ürün silindi");
                ToDoList();
            }
            connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            bool status = rdbCompleted.Checked;
            var connection = new NpgsqlConnection(connectionString);

            connection.Open();
            string query = "UPDATE todolists SET title=@title, description=@description, status=@status, priority=@priority, categoryid=@categoryId WHERE id = @id";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@title", txtTitle.Text); // Başlık
                command.Parameters.AddWithValue("@description", txtDescription.Text); // Açıklama
                command.Parameters.AddWithValue("@status", status); // Durum
                command.Parameters.AddWithValue("@priority", txtPriority.Text); // Öncelik
                command.Parameters.AddWithValue("@categoryId", int.Parse(cmbCategory.SelectedValue.ToString())); // Kategori ID
                command.Parameters.AddWithValue("@id", id); // Güncellenecek ID

                command.ExecuteNonQuery(); // Sorguyu çalıştır
                MessageBox.Show("Yapılacak iş güncellendi");
                ToDoList(); // Güncellenmiş listeyi yenile
            }

            connection.Close(); // Bağlantıyı kapat
        }

        private void btnCheckedList_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM todolists WHERE status = true ORDER BY id";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void btnContinuedList_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM todolists WHERE status = false ORDER BY id";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void btnAllList_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                // Sorgu: ToDoLists ile Categories tablosunu birleştirip kategori adını getirme
                string query = "SELECT t.title, t.description, t.status, t.priority, c.name as category_name FROM ToDoLists t   JOIN Categories c ON t.categoryId = c.id   ORDER BY t.id";

                var command = new NpgsqlCommand(query, connection);
                var adapter = new NpgsqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }
    }
}
