using Order.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contracts.Infrastructure
{
    internal interface IEmailService
    {
        Task<bool> SendMail(Email email);
    }
}
