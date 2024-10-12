using MailKit.Net.Smtp;
using MimeKit;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbMailActivationEntities context = new DbMailActivationEntities();
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int confirmCode = random.Next(100000, 1000000);

            Users user = new Users();
            user.Email = txtMail.Text;
            user.Name = txtName.Text;
            user.Surname = txtSurname.Text;
            user.Password = txtPassword.Text;
            user.IsConfirm = false;
            user.ActivationCode = confirmCode.ToString(); 

            context.Users.Add(user);
            context.SaveChanges();

            #region Mail Gönderme İşlemi

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("AdminRegister", "fatmabrl11@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", txtMail.Text);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Email adresinizin doğrulama kodu: " + confirmCode;

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Email Doğrulama Kodu";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("fatmabrl11@gmail.com", "ugyjshgassrgzuqw");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            MessageBox.Show("Hesabınıza mail doğrulama kodu gönderilmiştir");

            FrmMailConfirm frmMailConfirm = new FrmMailConfirm();
            frmMailConfirm.email = txtMail.Text;
            frmMailConfirm.Show();



            #endregion

        }
    }
}
