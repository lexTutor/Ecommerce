using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Core.RepositoryAbstractions
{
    public interface IPersonalIssueRepository : IGenericRepository<PersonalIssue>
    {
        Task<PersonalIssue> GetPersonalIsssue(string personalIssueId);
        Task<ICollection<PersonalIssue>> GetAllPersonalIssuesforAUser(string userId);
    }
}
