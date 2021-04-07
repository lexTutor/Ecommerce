using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.DataAccess;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Services.Repositories
{
    public class ChatRepository: GenericRepository<Chat>, IChatRepository
    {
        private readonly DataContext _ctx;
        public ChatRepository(DataContext ctx): base(ctx)
        {
            _ctx = ctx;
        }
    }
}