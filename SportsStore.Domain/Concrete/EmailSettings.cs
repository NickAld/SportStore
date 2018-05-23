using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class EmailSettings
    {
        private const string myEmail = "nickald@mail.ru";

        public string MailToAddress = "rus-prapor@yandex.ru";
        public string MailFromAddress = myEmail;
        public bool UseSsl = true;
        public string Username = myEmail;
        public string Password = "!Dctdcfl11";
        public string ServerName = "smtp.mail.ru";
        public int ServerPort = 25;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\sports_store_emails";

        public EmailSettings()
        { }

        public EmailSettings(int port)
        {
            this.ServerPort = port;
        }
    }
}
