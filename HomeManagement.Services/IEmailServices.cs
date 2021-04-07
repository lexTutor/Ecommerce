using HomeManagement.Models;
using System.Threading.Tasks;

namespace HomeManagement.Services
{
    public interface IEmailServices
    {
        System.Threading.Tasks.Task<bool> SendEmailAsync(MailMessage message);
    }
}