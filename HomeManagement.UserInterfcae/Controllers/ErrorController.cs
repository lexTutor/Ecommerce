using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Controllers
{
    public class ErrorController: Controller
    {
        [HttpGet]
        [Route("Error/{statuscode}")]
        [AllowAnonymous]
        public IActionResult Error(int statusCode)
        {
            var statuscodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "We could not find the requested page... Quite sorry though...";
                    return View();
                case 403:
                    ViewBag.ErrorMessage = "Taa... You have no right to access that page";
                    return View();
                case 401:
                    ViewBag.ErrorMessage = "You are not authorized to access this page";
                    return View();
                case 414:
                    ViewBag.ErrorMessage = "The URI looks fishy...";
                    return View();
                default:
                    return View();
            }
        }


        [HttpGet]
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var statuscodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            return View();
        }


    }
}
