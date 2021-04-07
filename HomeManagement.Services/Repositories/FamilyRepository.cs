using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.DataAccess;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Services.Repositories
{
    public class FamilyRepository : GenericRepository<Family>, IFamilyRepository
    {
        private readonly DataContext _ctx;
        public FamilyRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
