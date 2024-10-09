using Project12_JwtTokenProject.JWT;
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

namespace Project12_JwtTokenProject
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-Q270QVE\\SQLEXPRESS; initial catalog=DbToken; integrated security= true");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            TokenGenerator tokenGenerator = new TokenGenerator();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * From Users Where Name=@username and Password=@password", sqlConnection);
            command.Parameters.AddWithValue("@username", txtUsername.Text);
            command.Parameters.AddWithValue("@password", txtPassword.Text);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            if(sqlDataReader.Read())
            {
                string token = tokenGenerator.GenerateJwtToken2(txtUsername.Text);
                //MessageBox.Show(token);
                FrmEmployee employee = new FrmEmployee();
                employee.tokenGet = token;
                employee.Show();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı ya da şifre");
                txtPassword.Clear();
                txtUsername.Clear();
                txtUsername.Focus();
            }
            sqlConnection.Close();
        }   
    }
}
