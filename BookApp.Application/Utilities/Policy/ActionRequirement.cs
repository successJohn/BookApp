using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Utilities.Policy
{
    public class ActionRequirement: IAuthorizationRequirement
    {
        public string Status { get; set; }
        public ActionRequirement(string status) 
        {
            Status = status;
        }
    }
}
