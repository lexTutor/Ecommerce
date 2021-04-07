using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.Models;
using HomeManagement.Models.ObjectRelationalMappers;
using HomeManagement.Models.ViewModels;
using HomeManagement.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManagement.UserInterfcae.Controllers
{
    /// <summary>
    /// Account Controller
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailServices _emailServices;
        private readonly IFamilyService _familyService;

        /// <summary>
        /// Account controller constructor
        /// </summary>
        /// <param name="signInManager"></param>
        /// <param name="userManager"></param>
        /// <param name="emailServices"></param>
        public AccountController(IServiceProvider serviceProvider)
        {
            _emailServices = serviceProvider.GetRequiredService<IEmailServices>();
            _familyService = serviceProvider.GetRequiredService<IFamilyService>();
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        }

        /// <summary>
        /// Get Family by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetFamilyById(string Id)
        {
            var result = await _familyService.GetFamily(Id);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        /// <summary>
        /// Sign Up a Family 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Family/SignUp")]
        public async Task<IActionResult> SignUpAFamily(NewFamilyDTO model)
        {
            var result = await _familyService.Add(model);
            if (!result.Success) { return BadRequest(result); }
            return CreatedAtRoute(nameof(GetFamilyById), new { Id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Send Invite to family Members
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Family/Invites")]
        public async Task<IActionResult> InviteFamilyMembers(FamilyMembersInviteDTO model)
        {
            var response = await _familyService.InviteUser(model, Url, Request.Scheme);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> LogIn(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if(user != null)
            {
              var check =  await _userManager.CheckPasswordAsync(user, model.Password);
                if (!check)
                {
                    return BadRequest("Invalid Credentials");
                }
                return Ok(user);
            }
            return BadRequest("InvalidCredentials");
        }

    }
  }
