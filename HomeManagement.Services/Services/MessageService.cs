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
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;
        public MessageService(IServiceProvider serviceProvider)
        {
            _messageRepository = serviceProvider.GetRequiredService<IMessageRepository>();
            _chatRepository = serviceProvider.GetRequiredService<IChatRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public async Task<Response<MessageReturnDTO>> CreateMessage(CreateMessageDTO model, string chatId)
        {
            //Upload Attachment to server and get url
            var message = _mapper.Map<Message>(model);
            message.ChatId = chatId;
          var result = await  _messageRepository.Add(message);
            var msg = await _messageRepository.GetById(message.Id);
            return new Response<MessageReturnDTO>
            {
                Success = result,
                Message = !result ? "Successfully" : "UnSuccessful",
                Data = _mapper.Map<MessageReturnDTO>(msg)
            };
        }

        public async Task<bool> DeleteMessage(string messageId)
        {
            return await _messageRepository.DeleteById(messageId);
        }

        public async Task<bool> EditMessage(EditMessageDTO model, string messageId)
        {
            var message = await _messageRepository.GetById(messageId);
            message.MessageDetails = model.MessageDetails;
           return await _messageRepository.Modify(message);
        }
    }
}
