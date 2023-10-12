using BookApp.Application.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Services
{
    
    public class ContextAccessor: IContextAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ContextAccessor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetCurrentUserId()
        {
            var identity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            var claim = identity.Claims;

            var userIdClaim = claim.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            return userIdClaim;
        }

        public string GetUserEmail()
        {
            throw new NotImplementedException();
        }
    
    }
}
