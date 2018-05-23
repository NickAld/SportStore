using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace SportsStore.Domain.Concrete
{
    public class EmailOrderProcessor : Abstract.IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {

            using (var smtpClient = new SmtpClient(emailSettings.ServerName, emailSettings.ServerPort))
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Timeout = 20000;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //var credit = new NetworkCredential(emailSettings.Username, emailSettings.Password, "mail.ru");
                var credit = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                
                //smtpClient.Credentials = credit;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                smtpClient.UseDefaultCredentials = false;

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                smtpClient.Send(GetMessage(cart, shippingInfo));
            }
        }

        public MailMessage GetMessage(Cart cart, ShippingDetails shippingInfo)
        {
            var body = new StringBuilder()
                    .AppendLine("Новый заказ принят")
                    .AppendLine("-----")
                    .AppendLine("Товары:");

            foreach (var line in cart.Lines)
            {
                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.City)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}", shippingInfo.GiftWrap ? "Yes" : "No");
            }

            MailMessage mailMessage = new MailMessage(emailSettings.MailFromAddress, emailSettings.MailToAddress, "Новый заказ", body.ToString());
            if (emailSettings.WriteAsFile)
            {
                mailMessage.BodyEncoding = Encoding.ASCII;
            }

            return mailMessage;
        }
    }
}
