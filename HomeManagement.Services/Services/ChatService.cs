using AutoMapper;
using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Services.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;
        public ChatService(IServiceProvider serviceProvider)
        {
            _chatRepository = serviceProvider.GetRequiredService<IChatRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
        public async Task<Response<ICollection<ChatReturnAllDTO>>> GetAllChatsForAUser(string UserId)
        {
            var chats = await _chatRepository.GetAllChatsForAUser(UserId);
            return new Response<ICollection<ChatReturnAllDTO>>
            {
                Success = chats == null,
                Data = chats == null ? null : _mapper.Map<ICollection<ChatReturnAllDTO>>(chats),
                Message = chats == null ? "No chats" : "All chats"
            };

        }

        public async Task<Response<ChatReturnDTO>> GetChat(string Id)
        {
            var chat = await _chatRepository.GetChat(Id);
            return new Response<ChatReturnDTO>
            {
                Success = chat == null,
                Data = chat == null? null : _mapper.Map<ChatReturnDTO>(chat),
                Message = chat ==null? "No chats": $"Chat with {chat.UserTo.FirstName}"
            };
        }
        public Task<bool> DeleteChat(string Id)
        {
            return _chatRepository.DeleteById(Id);  
        }
    }
}
