using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Policies
{
    public static class Policies
    {
        /// <summary>
        /// Admin role for our policy
        /// </summary>
        public const string Parent = "Parent";
        /// <summary>
        /// Decadev role for our policy
        /// </summary>
        public const string Guardian = "Guardian";
        /// <summary>
        /// Vendor role for our policy
        /// </summary>
        public const string Child = "Child";

        /// <summary>
        /// Grants Parents User rights
        /// </summary>
        /// <returns></returns>
        public static AuthorizationPolicy ParentPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Parent).Build();
        }

        /// <summary>
        ///Grants guardians User rights
        /// </summary>
        /// <returns></returns>
        public static AuthorizationPolicy GuardianPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Guardian).Build();
        }

        /// <summary>
        /// Grants children User rights
        /// </summary>
        /// <returns></returns>
        public static AuthorizationPolicy ChildPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Child).Build();
        }

    }
}
