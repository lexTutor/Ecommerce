using HomeManagement.Models;
using System.Threading.Tasks;

namespace HomeManagement.Services
{
    public interface IEmailServices
    {
        Task SendEmailAsync(MailMessage message);
    }
}