using Order.Application.Contracts.Infrastructure;
using Order.Application.Model;


namespace Order.Application.Services
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendMail(Email email)
        {
            //use smtp server here to send an email;
            return await Task.Run(() => true);
        }
    }
}
