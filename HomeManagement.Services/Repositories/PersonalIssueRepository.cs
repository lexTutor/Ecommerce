using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.DataAccess;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Services.Repositories
{
    public class PersonalIssueRepository: GenericRepository<PersonalIssue>, IPersonalIssueRepository
    {
        private readonly DataContext _ctx;
        public PersonalIssueRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
