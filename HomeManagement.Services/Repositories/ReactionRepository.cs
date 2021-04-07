using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.DataAccess;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Services.Repositories
{
    public class ReactionRepository: GenericRepository<Reaction>, IReactionRepository
    {
        private readonly DataContext _ctx;
        public ReactionRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
