using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net.Mail;
using System.Net;

namespace ACUManager
{
    public partial class frmForgot : DevExpress.XtraEditors.XtraForm
    {
        public frmForgot()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Users u = Users.GetForgotUser(txtAccount.Text);
            if(u!=null)
            {
                string email = u.Email;
                if(email== txtEmail.Text)
                {
                    try
                    {
                        string fromaddr = "lefa.acu.manager@gmail.com";
                        string password = "m12071993";

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
                        mail.Subject = "Get password";
                        NetworkCredential nc = new NetworkCredential(fromaddr, password);
                        client.Credentials = nc;
                        mail.Body = string.Format("Name: {0}\r\nAccount: {1}\r\nPassword: {2}", u.Name, u.UserName, u.PassWord);
                        client.Send(mail);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return;
                    }

                    MessageBox.Show("Get password success. Please check your email!");


                }
                else
                {
                    MessageBox.Show("Email address wrong!");
                }
            }
            else
            {
                MessageBox.Show("Can't find user!");
            }
        }
    }
}