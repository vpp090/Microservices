﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Order.Application.Contracts.Infrastructure;
using Order.Application.Model;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Order.Infrastructure.Services
{
    public class EmailService : IEmailService
    {

        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendMail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            _logger.LogInformation("Email_Service_Email_Sent");

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted ||
                response.StatusCode == System.Net.HttpStatusCode.OK)
                     return true;

            _logger.LogError("Email sending failed");

            return false;
        }
    }
}
