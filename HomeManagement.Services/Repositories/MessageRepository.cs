using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.DataAccess;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Services.Repositories
{
    public class MessageRepository: GenericRepository<Message>, IMessageRepository
    {
        private readonly DataContext _ctx;
        public MessageRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
