using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace ACUManager
{
    public partial class ucHelp : UserControl
    {
        string userId;
        public ucHelp()
        {
            InitializeComponent();
        }

        public ucHelp(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void ucHelp_Load(object sender, EventArgs e)
        {
            try
            {
                Users u = Users.LoadUsersById(userId);
                if(u!=null)
                {
                    txtName.Text = u.Name;
                    txtPhone.Text = u.PhoneNo;
                    txtEmail.Text = u.Email;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if(txtSubject.Text.Count()<=0)
            {
                MessageBox.Show("Subject can't empty!");
                txtSubject.Focus();
                return;
            }

            if (txtContent.Text.Count() <= 0)
            {
                MessageBox.Show("Email content can't empty!");
                txtContent.Focus();
                return;
            }

            try
            {
                string fromaddr = "lefa.acu.user@gmail.com";
                string password = "m12071993";
                string email = "lefa.acu.manager@gmail.com";

                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress(fromaddr);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                mail.Subject = txtSubject.Text;
                NetworkCredential nc = new NetworkCredential(fromaddr, password);
                client.Credentials = nc;
                mail.Body = string.Format("Name: {0}\r\nPhone: {1}\r\nEmail: {2}\r\nRequest: {3}", txtName.Text, txtPhone.Text, txtEmail.Text,txtContent.Text);
                client.Send(mail);                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            MessageBox.Show("Your request has been sent to administrator!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucDashBoard uc = new ucDashBoard(userId);
            Common.GoBack(uc, this);
        }

       
    }
}
