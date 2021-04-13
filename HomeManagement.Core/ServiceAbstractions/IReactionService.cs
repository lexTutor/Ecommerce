using HomeManagement.DTO;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Core.ServiceAbstractions
{
    public interface IReactionService
    {
        Task<Response<string>> AddReaction(AddReactionDTO model, string Id);

        Task<bool> EditReaction(string emoji, string reactionId);

        Task<bool> DeleteReaction(string reactionId);
    }
}
