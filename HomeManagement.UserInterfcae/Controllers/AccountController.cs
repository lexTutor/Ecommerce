using HomeManagement.Models;
using HomeManagement.Models.ObjectRelationalMappers;
using HomeManagement.Models.ViewModels;
using HomeManagement.Services;
using HomeManagement.UserInterface.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManagement.UserInterfcae.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailServices _emailServices;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IEmailServices emailServices)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailServices = emailServices;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Details are Incorrect");
                return View();
            }
            if (!user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, model.Password)))
            {
                ModelState.AddModelError(string.Empty, "Email not confirmed");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Details are InCorrect");
                return View();
            }
            //return to home if login is successful
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = AccounMappers.MapSignUpToAppUser(model);
            await _userManager.CreateAsync(user, model.Password);
            //await _userManager.AddToRoleAsync(user, "Parent");

            //Send confirmation Email
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var emailConfirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);
            var mailSubject = System.IO.File.ReadAllText("../HomeManagement.UserInterfcae/wwwroot/EmailBodies/TestInvite.html");
            var mailSubject2 = System.IO.File.ReadAllText("../HomeManagement.UserInterfcae/wwwroot/EmailBodies/GuardianInvite.html");
            var s = string.Format("<a href ={0} target ='_blank' style = 'color: aliceblue'> Accept Invite </a>", emailConfirmationLink);
            mailSubject += s + mailSubject2;
            var message = new MailMessage(new List<string> {  model.EmailAddress}, mailSubject, emailConfirmationLink);
            await _emailServices.SendEmailAsync(message);

            return RedirectToAction("GoClickYourLink", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                ViewBag.ErrorTitle = "You seem lost. Are you";
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorTitle = "You seem lost. Are you?";
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }
            else
                ViewBag.ErrorTitle = "Email not found";
            return View("Error");

        }

        public IActionResult GoClickYourLink()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SendInvite()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendInvite(SendInviteVM model)
        {
          var user =  _userManager.FindByEmailAsync(model.EmailAddress);
            if (user != null)
            {
                ModelState.AddModelError(string.Empty, "User already exists");
                return View();
            }

            //Creates the AppUser from the recieved model
            var invitedUser = AccounMappers.MapInviteToAppUser(model);
           await _userManager.CreateAsync(invitedUser, model.Password);
           await _userManager.AddToRoleAsync(invitedUser, model.InviteType);

            //Generates the email confirmation token and sends the mail to the invited user
            var token = _userManager.GenerateEmailConfirmationTokenAsync(invitedUser);
            var emailConfirmationLink = Url.Action("AcceptInvite", "Account", new { userId = user.Id, token = token, role = model.InviteType }, Request.Scheme);
            var type = model.InviteType + "Invite.html";
            var mailSubject = System.IO.File.ReadAllText(string.Format("../HomeManagement.UserInterfcae/wwwroot/EmailBodies/{0}", type));
            mailSubject += emailConfirmationLink;
            var message = new MailMessage(new List<string> { model.EmailAddress }, mailSubject, emailConfirmationLink);
            await _emailServices.SendEmailAsync(message);

            ViewBag.Result = "User has been ivited successfully";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AcceptInvite(string userId, string token, string role)
        {
            if ( userId == null || token == null)
            {
                ViewBag.ErrorTitle = "You seem lost. Are you?";
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorTitle = "You seem lost. Are you?";
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
             await _signInManager.PasswordSignInAsync(user, user.PasswordHash, true, false);
                return RedirectToAction("UpdateInformation");
            }
            else
                ViewBag.ErrorTitle = "Email not found";
            return View("Error");
        }

        [HttpGet]
        public IActionResult UpdateInformation()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInformation(UpdateInfoVM model)
        {
            //Gets the current signed in user
            var user = await  _userManager.GetUserAsync(User);

            //Update Information
            //-------------------------------
            var updatedUser =   AccounMappers.UpdateAppUser(user, model);

            //Save changes
            var result =  await  _userManager.UpdateAsync(updatedUser);

            //Return to home
            return RedirectToAction("Index", "Home");
        }

    }
  }
