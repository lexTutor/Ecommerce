using AutoMapper;
using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.Models;
using Microsoft.AspNetCore.Identity;
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
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public ChatService(IServiceProvider serviceProvider)
        {
            _chatRepository = serviceProvider.GetRequiredService<IChatRepository>();
            _messageService = serviceProvider.GetRequiredService<IMessageService>();
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
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
            Chat chat = await _chatRepository.GetChat(Id);
            return new Response<ChatReturnDTO>
            {
                Success = chat == null,
                Data = chat == null ? null : _mapper.Map<ChatReturnDTO>(chat),
                Message = chat == null ? "No chats" : $"Chat with {chat.UserTo.FirstName}"
            };
        }


        public Task<bool> DeleteChat(string Id)
        {
            return _chatRepository.DeleteById(Id);
        }

        public async Task<Response<ChatReturnDTO>> CreateChat(string userToId, string userFromId, CreateMessageDTO model)
        {
            Response<ChatReturnDTO> response = new Response<ChatReturnDTO>();
            var userTo = await _userManager.FindByIdAsync(userToId);
            var userFrom = await _userManager.FindByIdAsync(userFromId);

            if (userTo == null || userFrom == null)
            {
                response.Success = false;
                response.Message = "Invalid credentials";
            }
            else
            {
                Chat chat = new Chat { UserFromId = userFromId, UserToId = userToId };
              var result =  await _chatRepository.Add(chat);
                if (!result)
                {
                    response.Success = false;
                    response.Message = "Invalid credentials";
                }
                else
                {
                    var msg = await _messageService.CreateMessage(model, chat.Id);
                    if (!msg.Success)
                    {
                        response.Success = false;
                        response.Message = "Message not added successfully";
                    }
                    else
                    {
                        var getChat = await _chatRepository.GetById(chat.Id);

                        response.Success = true;
                        response.Message = "Added successfully";
                        response.Data = _mapper.Map<ChatReturnDTO>(getChat);
                    }
                }
            }
            return response;
        }
    }
}
