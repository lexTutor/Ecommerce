using AutoMapper;
using HomeManagement.Commons;
using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.DTO.ManualMapper;
using HomeManagement.DTO.Profiles;
using HomeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Services.Services
{
    public class FamilyServices: IFamilyService
    {
        private readonly IMapper _mapper;
        private readonly IFamilyRepository _familyRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailServices _emailServices;
        public FamilyServices(IServiceProvider serviceProvider)
        {
            _familyRepository = serviceProvider.GetRequiredService<IFamilyRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _emailServices = serviceProvider.GetRequiredService<IEmailServices>();
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        }
        public async Task<Response<Family>> Add(NewFamilyDTO model)
        {
          var family =  _mapper.Map<Family>(model);
          var result = await  _familyRepository.Add(family);
            if (!result)
            {
                return new Response<Family>
                {
                    Success = false,
                    Message = "Family not added successfully"
                };
            }
            return new Response<Family>
            {
                Success = true,
                Message = "Family added successfully",
                Data = family
            };
        }

        public async Task<Response<FamilyDTO>> GetFamily(string Id)
        {
            var family = await _familyRepository.GetById(Id);
            if (family != null)
                return new Response<FamilyDTO>
                {
                    Success = true,
                    Data = _mapper.Map<FamilyDTO>(family)
                };
            return new Response<FamilyDTO>
            {
                Success = false,
                Message = "family Not found"
            };
        }

        public async Task<Response<List<FamilyInviteReturnDTO>>> InviteUser(FamilyMembersInviteDTO model, IUrlHelper url, string requestScheme)
        {
            var _data = new Dictionary<string, string>();
            var VerifiedMails = await VerifyMail(model.Emails, _data);
            _data = VerifiedMails.Data;

            if (VerifiedMails.Emails.Count == 0)
            {
                return new Response<List<FamilyInviteReturnDTO>>
                {
                    Success = false,
                    Data = Responses.MapToResponseMsg(_data),
                    Message = "Emails are Invalid"
                };
            }

            var tokens = await CreateUserAndPassword(VerifiedMails.Emails, _data);
            _data = tokens.Data;

            _data = await SendMail(tokens.UserAndPassword, url, requestScheme, _data);

            return new Response<List<FamilyInviteReturnDTO>>
            {
                Success = true,
                Data = Responses.MapToResponseMsg(_data),
                Message = "Invites sent"
            };
        }

        private async Task<Dictionary<string, string>> SendMail(Dictionary<AppUser, string> userAndPassword, IUrlHelper url, string requestScheme,  Dictionary<string, string> data)
        {
            foreach (var user in userAndPassword)
            {

                var emailConfirmationLink = url.Action("Login", "Auth", new { Email = user.Key.Email, Password = user.Value }, requestScheme);

                //SentUp email Body
                //var inviteA = File.ReadAllText(Path.Combine(path, "StaticFiles/InvitationA.html"));
                //var password = string.Format("<p><strong> Your default password is {0} </strong></p>", user.Value);
                //var linkInBetween = string.Format("<a href = {0} target ='_blank' style = 'color: aliceblue'> Accept Invite </a>", emailConfirmationLink);
                //var inviteB = File.ReadAllText(Path.Combine(path, "StaticFiles/InvitationB.html"));
                //var emailBody = inviteA + password + linkInBetween + inviteB;

                //Send the mail
                var mail = new MailMessage(new List<string> { user.Key.Email }, "Home Management App", "emailbody");
               var result = await _emailServices.SendEmailAsync(mail);
                
                if (result) 
                { 
                    data.Add(user.Key.Email, user.Key.Id);
                }
                else
                {
                    await _userManager.DeleteAsync(user.Key); data.Add(user.Key.Email, "NotSent");
                }
            }

            return data;
        }

        private async Task<TokenReturn> CreateUserAndPassword(IEnumerable<string> emails, Dictionary<string, string> data)
        {
            var result = new TokenReturn { Data = data };
            foreach (var email in emails)
            {

                var newUser = new AppUser { Email = email, UserName = email};
                var password = Guid.NewGuid().ToString();
                password = password.Replace('-', '@');
                var createdUser = await _userManager.CreateAsync(newUser, password);

                if (!createdUser.Succeeded)
                {
                    result.Data.Add(email, "NotSent");
                }
                else
                {
                    result.UserAndPassword.Add(newUser, password);
                }
            }
            return result;
        }

        private async Task<EmailCheck> VerifyMail(IEnumerable<string> emails, Dictionary<string, string> data)
        {
            var result = new EmailCheck { Data = data };

            foreach (var email in emails)
            {
                if (MailUtilities.VerifyMails(email, result.Data))
                {
                    var checkUser = await _userManager.FindByEmailAsync(email);
                    if (checkUser != null)
                        result.Data.Add(email, "Email already exists");
                    else
                        result.Emails.Add(email);
                }
                else
                    result.Data.Add(email, "InvalidMail");
            }
            return result;
        }

     
    }
}
