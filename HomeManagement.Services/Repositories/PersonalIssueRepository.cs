using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.DataAccess;
using HomeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public async System.Threading.Tasks.Task<ICollection<PersonalIssue>> GetAllPersonalIssuesforAUser(string userId)
        {
            var result = await _ctx.PersonalIssues.Include(issue => issue.IssueFrom).
                           Where(issue => issue.IssueFrom.Id == userId).ToListAsync();
            return result;
        }

        public async System.Threading.Tasks.Task<PersonalIssue> GetPersonalIsssue(string personalIssueId)
        {
            var result = await _ctx.PersonalIssues.Include(issue => issue.IssueFrom)
                .Include(issue => issue.Reactions).FirstOrDefaultAsync(issue => issue.Id == personalIssueId);
            return result;
        }
    }
}
