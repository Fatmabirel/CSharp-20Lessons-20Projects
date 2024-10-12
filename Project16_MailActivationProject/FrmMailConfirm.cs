using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project16_MailActivationProject
{
    public partial class FrmMailConfirm : Form
    {
        public FrmMailConfirm()
        {
            InitializeComponent();
        }

        DbMailActivationEntities context = new DbMailActivationEntities();
        public string email;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var value = context.Users.Where(x => x.Email == txtMail.Text).Select(y => y.ActivationCode).FirstOrDefault();
            if(txtActivationCode.Text == value.ToString())
            {
                var value2 = context.Users.Where(x => x.Email == txtMail.Text).FirstOrDefault();
                value2.IsConfirm = true;
                context.SaveChanges();
                MessageBox.Show("Hesabınız aktif edildi");
            }
            else
            {
                MessageBox.Show("Hatalı kod");
            }
        }

        private void FrmMailConfirm_Load(object sender, EventArgs e)
        {
            txtMail.Text = email;
        }
    }
}
