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
        private readonly IEmailServices _emailServices;
        private readonly IJWTService _jwtService;
        private readonly UserManager<AppUser> _userManager;
        public FamilyServices(IServiceProvider serviceProvider)
        {
            _familyRepository = serviceProvider.GetRequiredService<IFamilyRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _emailServices = serviceProvider.GetRequiredService<IEmailServices>();
            _jwtService = serviceProvider.GetRequiredService<IJWTService>();
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        }
        public async Task<Response<FamilyDTO>> Add(NewFamilyDTO model)
        {
          var family =  _mapper.Map<Family>(model);
          var result = await  _familyRepository.Add(family);

            var newUser = new AppUser { Email = model.EmailAddress, UserName = model.EmailAddress, FamilyId = family.Id, FirstName = model.FirstName, LastName = model.FirstName };
            var createdUser = await _userManager.CreateAsync(newUser, model.Password);

            Response<FamilyDTO> response = new Response<FamilyDTO>();
            if (!result || !createdUser.Succeeded)
            {
                response.Success = false;
                response.Message = "Family not added successfully";
                return response;
            }

           await _userManager.AddToRoleAsync(newUser, "Parent");
            var dto = _mapper.Map<FamilyDTO>(family);
            dto.Token = await _jwtService.GetToken(newUser);

            response.Success = true;
            response.Message = "Family added successfully";
            response.Data = dto;

            return response;
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

        public async Task<Response<List<FamilyInviteReturnDTO>>> InviteUser(FamilyMembersInviteDTO model, IUrlHelper url, string requestScheme, string familyId)
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

            var tokens = await CreateUserAndPassword(VerifiedMails.Emails, _data, familyId);
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

                var emailConfirmationLink = url.Action("Login", "User", new { Email = user.Key.Email, Password = user.Value }, requestScheme);

                //SentUp email Body
                var inviteA = File.ReadAllText("StaticFiles/EmailBodies/EmailInvite.HTML");
                var password = string.Format("<p><strong> Your default password is {0} </strong></p>", user.Value);
                var linkInBetween = string.Format("<a href = {0} target ='_blank' style = 'color: aliceblue'> Accept Invite </a>", emailConfirmationLink);
                var emailBody = password + linkInBetween;

               var mailInvite = inviteA.Replace("abcdefghijk", emailBody);

                //Send the mail
                var mail = new MailMessage(new List<string> { user.Key.Email }, mailInvite, "Home Management App");
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

        private async Task<TokenReturn> CreateUserAndPassword(IEnumerable<string> emails, Dictionary<string, string> data, string familyId)
        {
            var result = new TokenReturn { Data = data };
            foreach (var email in emails)
            {

                var newUser = new AppUser { Email = email, UserName = email, FamilyId = familyId};
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
