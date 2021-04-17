using HomeManagement.DTO;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Core.ServiceAbstractions
{
    public interface IChatService
    {
        Task<Response<ICollection<ChatReturnAllDTO>>> GetAllChatsForAUser(string UserId);

        Task<Response<ChatReturnDTO>> GetChat(string Id);
        Task<Response<ChatReturnDTO>> CreateChat(string userToId, string userFromId, CreateMessageDTO model);

        Task<bool> DeleteChat(string Id);
    }
}
