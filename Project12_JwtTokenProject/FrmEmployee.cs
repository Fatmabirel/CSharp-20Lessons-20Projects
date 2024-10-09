using Project12_JwtTokenProject.JWT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project12_JwtTokenProject
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }
        public string tokenGet;
        SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-Q270QVE\\SQLEXPRESS; initial catalog=DbToken; integrated security= true");
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            TokenValidator tokenValidator = new TokenValidator();

            richTextBox1.Text = tokenGet;
            var principle = tokenValidator.ValidateJwtToken(tokenGet);
           
            if (principle != null)
            {
                string username = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                MessageBox.Show("Hoş geldiniz: " + username);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("Select * From Employees", sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Geçersiz Token");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
