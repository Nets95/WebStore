using OnlineWebStore.Domain.Astract;
using OnlineWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OnlineWebStore.Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.UserName,
                    emailSettings.Password);
                StringBuilder body = new StringBuilder()
                .AppendLine("A new order has been submitted")
                .AppendLine("---")
                .AppendLine("Items:");
                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0}  {1} (subtotal: {2:c}", line.Quantity, line.Product.Name, subtotal);

                }
                try
                {
                    body.AppendFormat("Total order value: {0:c}", cart.ComputeValue())
                   .AppendLine("---")
                   .AppendLine("Ship to:")
                   .AppendLine(shippingDetails.Name)
                   .AppendLine(shippingDetails.Line1)
                   .AppendLine(shippingDetails.Line2 ?? "")
                   .AppendLine(shippingDetails.Line3 ?? "")
                   .AppendLine(shippingDetails.City)
                   .AppendLine(shippingDetails.State)
                   .AppendLine(shippingDetails.Country)
                   .AppendLine(shippingDetails.Zip)
                   .AppendLine("---")
                   .AppendFormat("Gift wrap: {0}",
                   shippingDetails.GiftWrap ? "yes" : "No");
                    MailMessage mailMessage = new MailMessage(
                        emailSettings.MailFromAddress,
                        emailSettings.MailToAddress,
                        "New order submited",
                        body.ToString());
                    smtpClient.Send(mailMessage);
                }
                catch (System.Net.Mail.SmtpException)
                {
                    Console.WriteLine("qqq");
                }

            }
        }
    }
}

