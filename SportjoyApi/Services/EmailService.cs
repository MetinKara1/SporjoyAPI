using Core.Services;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;

namespace Services
{
    public class EmailService : IEmailService
    {
        public void Send(string from, string to, string subject, string html)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            //var email = new MailMessage()
            //{
            //    From = new MailAddress(from),
            //    To = { to },
            //    Subject = subject,
            //    Body = html,
            //    DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            //};

            // send email
            //using var smtp = new System.Net.Mail.SmtpClient(("mail.sporjoy.com"));
            //smtp.Credentials = new NetworkCredential("info@sporjoy.com", "R%t060ao");
            //smtp.Port = 587;
            //smtp.EnableSsl = false;
            //smtp.Send(email);
            //smtp.Dispose();


            using var smtp = new SmtpClient();
            smtp.Connect("mail.sporjoy.com", 587, SecureSocketOptions.None);
            smtp.Authenticate("info@sporjoy.com", "R%t060ao");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
