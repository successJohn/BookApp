using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Utilities.Policy
{
    public class ActionRequirementHandler: AuthorizationHandler<ActionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ActionRequirement requirement)
        {
            var actionClaim = context.User.Claims.Where(x => x.Type == "Permission").ToList();

            if (!actionClaim.Any() || !actionClaim.Any(x => x.Value.Contains(requirement.Status)))
            {
                return Task.CompletedTask;
            }
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
