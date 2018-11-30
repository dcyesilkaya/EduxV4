using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxV4.Admin.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
