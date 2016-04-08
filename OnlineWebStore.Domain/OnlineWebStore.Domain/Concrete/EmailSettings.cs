using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineWebStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "uuu_aaa95@mail.ru";
        public string MailFromAddress = "uuu_aaa95@mail.ru";
        public bool UseSsl = true;
        public string UserName = "uuu aaa";
        public string Password = "12345uq";
        public string ServerName = "smtp.mail.ru";
        public int ServerPort = 551;
    }
}
