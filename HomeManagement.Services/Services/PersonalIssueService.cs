using AutoMapper;
using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Services.Services
{
    public class PersonalIssueService : IPersonalIssueService
    {
        private readonly IPersonalIssueRepository _PersonalIssueRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public PersonalIssueService(IServiceProvider serviceProvider)
        {
            _PersonalIssueRepository = serviceProvider.GetRequiredService<IPersonalIssueRepository>();
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
        public async Task<Response<PersonalIssueReturnDTO>> CreatePersonalIssue(CreatePersonalIssueDTO model)
        {
            var newModel = _mapper.Map<PersonalIssue>(model);
            var result = await _PersonalIssueRepository.Add(newModel);
            if (!result)
                return new Response<PersonalIssueReturnDTO>
                {
                    Success = false,
                    Message = "Issue not created"
                };
            return new Response<PersonalIssueReturnDTO>
            {
                Success = true,
                Data = _mapper.Map<PersonalIssueReturnDTO>(newModel)
            };
        }

        public Task<bool> DeletePersonalIssue(string TaskIssueId)
        {
            return _PersonalIssueRepository.DeleteById(TaskIssueId);
        }

        public async Task<bool> EditPersonalIssue(EditPersonalIssueDTO model)
        {
            var issue = await _PersonalIssueRepository.GetById(model.Id);
            if (issue != null)
            {
                issue.IssueDetails = string.IsNullOrWhiteSpace(model.IssueDetails) ? issue.IssueDetails : model.IssueDetails;
                issue.IssueImage = string.IsNullOrWhiteSpace(model.IssueImage) ? issue.IssueImage : model.IssueImage;
                return await _PersonalIssueRepository.Modify(issue);
            }
            return false;
        }

        public async Task<Response<ICollection<PersonalIssueReturnAllDTO>>> GetALLPersonalIssues(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new Response<ICollection<PersonalIssueReturnAllDTO>>
                {
                    Message = "Invalid Id",
                    Success = false
                };
            }
            var result = await _PersonalIssueRepository.GetAllPersonalIssuesforAUser(userId);
            if (result == null)
                return new Response<ICollection<PersonalIssueReturnAllDTO>>
                {
                    Message = "No Personal Issues",
                    Success = true
                };
            return new Response<ICollection<PersonalIssueReturnAllDTO>>
            {

                Data = _mapper.Map<ICollection<PersonalIssueReturnAllDTO>>(result),
                Success = true
            };
        }

        public async Task<Response<PersonalIssueReturnDTO>> GetPersonalIssueById(string issueId)
        {
            var userIssue = await _PersonalIssueRepository.GetPersonalIsssue(issueId);
            if (userIssue == null)
                return new Response<PersonalIssueReturnDTO>
                {
                    Message = "Invalid Id",
                    Success = false
                };
            return new Response<PersonalIssueReturnDTO>
            {

                Data = _mapper.Map<PersonalIssueReturnDTO>(userIssue),
                Success = true
            };
        }

        public async Task<bool> MarkPersonalIssueAsResolved(string userIssueId)
        {
            var personalIssue = await _PersonalIssueRepository.GetPersonalIsssue(userIssueId);
            if (personalIssue != null)
            {
                personalIssue.IsResolved = true;
                return await _PersonalIssueRepository.Modify(personalIssue);
            }
            return false;
        }
    }
}
