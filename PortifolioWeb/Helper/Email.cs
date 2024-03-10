using System.Net;
using System.Net.Mail;

namespace PortifolioWeb.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;
        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool SendEmail(string email, string title, string message)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMPT:Host");
                string nome = _configuration.GetValue<string>("SMPT:Nome");
                string userName = _configuration.GetValue<string>("SMPT:UserName");
                string senha = _configuration.GetValue<string>("SMPT:Senha");
                int port = _configuration.GetValue<int>("SMPT:Porta");

                MailMessage mailMessage = new()
                {
                    From = new MailAddress(userName, nome)

                };

                mailMessage.To.Add(email);
                mailMessage.Subject = title;
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;

                using (SmtpClient smpt = new SmtpClient(host, port)) 
                {
                    smpt.Credentials = new NetworkCredential(userName, senha);
                    smpt.EnableSsl = true;

                    smpt.Send(mailMessage); 

                    return true;
                }

            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
