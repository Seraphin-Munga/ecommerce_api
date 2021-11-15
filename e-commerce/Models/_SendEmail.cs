using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace e_commerce.Models
{
    public class _SendEmail
    {
        public static async Task sendEmailAsync(string reciverEmail, string emailBody, string subject, bool add_CC)
        {
            await Task.Run(() =>
            {
                SmtpClient client = new SmtpClient("mail.sneakers-take.com")
                {
                    Port = 25,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("info@sneakers-take.com", "sera1234!@")
                };

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("info@sneakers-take.com");

                if (add_CC == true)
                {
                    mailMessage.CC.Add(new MailAddress("info@sneakers-take.com"));
                }

                mailMessage.To.Add(reciverEmail);
                mailMessage.Body = emailBody;
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);
            });
        }



    }
}
