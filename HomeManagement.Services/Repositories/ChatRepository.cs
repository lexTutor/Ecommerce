using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.DataAccess;
using HomeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Services.Repositories
{
    public class ChatRepository: GenericRepository<Chat>, IChatRepository
    {
        private readonly DataContext _ctx;
        public ChatRepository(DataContext ctx): base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<Chat>> GetAllChatsForAUser(string userFromId)
        {
            var result = await _ctx.Chat
                 .Where(chat => chat.UserFromId == userFromId)
                 .Include(chat => chat.UserFrom)
                 .Include(chat => chat.UserTo)
                 .Include(chat => chat.Message)
                 .OrderBy(chat => chat.Message.OrderBy(message => message.MessageDate)).ToListAsync();
            return result;
        }

        public async Task<Chat> GetChat(string chatId)
        {
            var result = await _ctx.Chat.
                Include(chat => chat.UserFrom)
                .Include(chat => chat.UserTo)
                .Include(chat=> chat.Message)
                .FirstOrDefaultAsync(Chat => Chat.Id == chatId);
            return result;
        }
    }
}