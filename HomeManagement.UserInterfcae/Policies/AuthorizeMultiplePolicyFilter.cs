using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Policies
{
    public class AuthorizeMultiplePolicyFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _authorization;
        private readonly string[] _policies;
        public AuthorizeMultiplePolicyFilter(string[] policies, IAuthorizationService authorization)
        {
            _authorization = authorization;
            _policies = policies;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            foreach (var policy in _policies)
            {
                var authorized = await _authorization.AuthorizeAsync(context.HttpContext.User, policy);
                if (!authorized.Succeeded)
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }
        }
    }
}