using AutoMapper;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO.AutoMapper
{
    public class ChatProfile: Profile
    {
        public ChatProfile()
        {
            //source => target
            CreateMap<ICollection<Chat>, ICollection<ChatReturnAllDTO>>();
            CreateMap<Chat, ChatReturnDTO>();

            //Message
            CreateMap<CreateMessageDTO, Message>();

            //Reactions
            CreateMap<AddReactionDTO, Reaction>();
        }
    }
}
