using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.Models;
using HomeManagement.Models.ObjectRelationalMappers;
using HomeManagement.Models.ViewModels;
using HomeManagement.Services;
using HomeManagement.UserInterface.Policies;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/HMA/v1/[controller]")]
    [Authorize]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _familyService;
        private readonly UserManager<AppUser> _userManager;

        /// <summary>
        /// Account controller constructor
        /// </summary>
        /// <param name="signInManager"></param>
        /// <param name="userManager"></param>
        /// <param name="emailServices"></param>
        public FamilyController(IServiceProvider serviceProvider)
        {
            _familyService = serviceProvider.GetRequiredService<IFamilyService>();
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        }

        /// <summary>
        /// Get Family by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}", Name = "GetFamilyById")]
        [Authorize(Policy = Policies.Parent)]
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
        [Route("SignUp")]
        [AllowAnonymous]
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
        [Route("Invites")]

        [Authorize(Policy = Policies.Parent)]
        public async Task<IActionResult> InviteFamilyMembers(FamilyMembersInviteDTO model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var response = await _familyService.InviteUser(model, Url, Request.Scheme, user.FamilyId);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

      }
  }
