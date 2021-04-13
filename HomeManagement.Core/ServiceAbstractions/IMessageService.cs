using HomeManagement.DTO;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Core.ServiceAbstractions
{
    public interface IMessageService
    {
        Task<Response<string>> CreateMessage(CreateMessageDTO model, string chatId);

        Task<bool> EditMessage(EditMessageDTO model, string messageId);

        Task<bool> DeleteMessage(string messageId);
    }
}
