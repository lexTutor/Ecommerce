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
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        public MessageService(IServiceProvider serviceProvider)
        {
            _messageRepository = serviceProvider.GetRequiredService<IMessageRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public async Task<Response<string>> CreateMessage(CreateMessageDTO model, string chatId)
        {
            //Upload Attachment to server and get url
            var message = _mapper.Map<Message>(model);
            message.ChatId = chatId;
          var result = await  _messageRepository.Add(message);
            return new Response<string>
            {
                Success = result,
                Message = !result ? "Successfully" : "UnSuccessful"
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
