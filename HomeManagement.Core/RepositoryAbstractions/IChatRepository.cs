using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Core.RepositoryAbstractions
{
    public interface IChatRepository : IGenericRepository<Chat>
    {
        Task<ICollection<Chat>> GetAllChatsForAUser(string userFromId);

        Task<Chat> GetChat(string chatId);
    }
}
