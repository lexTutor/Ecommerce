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
    public class ReactionService : IReactionService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IReactionRepository _reactionRepository;
        private readonly IMapper _mapper;
        public ReactionService(IServiceProvider serviceProvider)
        {
            _taskRepository = serviceProvider.GetRequiredService<ITaskRepository>();
            _messageRepository = serviceProvider.GetRequiredService<IMessageRepository>();
            _reactionRepository = serviceProvider.GetRequiredService<IReactionRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
        public async Task<Response<string>> AddReaction(AddReactionDTO model, string Id)
        {
            if(await _messageRepository.GetById(Id) != null)
            {
                var reaction = _mapper.Map<Reaction>(model);
                reaction.MessageId = Id;
              var result = await  _reactionRepository.Add(reaction);
                return new Response<string>
                {
                    Message = !result ? "Not successful" : "Successful",
                    Success = result
                };
            }
            else if (await _taskRepository.GetById(Id) != null)
            {
                var reaction = _mapper.Map<Reaction>(model);
                reaction.TaskId = Id;
                var result = await _reactionRepository.Add(reaction);
                return new Response<string>
                {
                    Message = !result ? "Not successful" : "Successful",
                    Success = result
                };
            }
            else
            {
                return new Response<string>
                {
                    Message = "Not successful",
                    Success = false
                };
            }
        }

        public async Task<bool> EditReaction(string emoji, string reactionId)
        {
            var reaction = await _reactionRepository.GetById(reactionId);
            reaction.Emoji = emoji;
           return await _reactionRepository.Modify(reaction);
        }

        public async Task<bool> DeleteReaction(string reactionId)
        {
            return await _reactionRepository.DeleteById(reactionId);
        }
    }
}
