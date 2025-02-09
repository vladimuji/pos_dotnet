using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using SaleSystem.BLL.Interfaces;
using SaleSystem.DAL.Interfaces;
using SaleSystem.Entity;

namespace SaleSystem.BLL.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IGenericRepository<Configuration> _repository;
        public EmailService(IGenericRepository<Configuration> repository)
        {
            _repository = repository;
        }
        public async Task<bool> SendEmail(string DestEmail, string Subject, string Msg)
        {
            try
            {
                IQueryable<Configuration> query = await _repository.Check(c => c.Src.Equals("Email_Service"));
                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Property, elementSelector: c => c.Val);
                var credentials = new NetworkCredential(Config["email"], Config["password"]);
                var email = new MailMessage()
                {
                    From = new MailAddress(Config["email"], Config["alias"]),
                    Subject = Subject,
                    Body = Msg,
                    IsBodyHtml = true
                };
                email.To.Add(new MailAddress(DestEmail));
                var serverClient = new SmtpClient()
                {
                    Host = Config["host"],
                    Port = int.Parse(Config["port"]),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true
                };
                serverClient.Send(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
