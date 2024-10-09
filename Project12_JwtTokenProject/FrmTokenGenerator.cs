using Project12_JwtTokenProject.JWT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project12_JwtTokenProject
{
    public partial class FrmTokenGenerator : Form
    {
        public FrmTokenGenerator()
        {
            InitializeComponent();
        }

        private void btnCreateToken_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtMail.Text;
            string name = txtName.Text;
            string surname = txtSurname.Text;

            TokenGenerator tokenGenerator = new TokenGenerator();
            string token = tokenGenerator.GenerateJwtToken(username,email, name, surname);
            richTextBox1.Text = token;
        }
    }
}
