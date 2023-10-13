using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Interface
{
    public interface IContextAccessor
    {
        string GetCurrentUserId();

        string GetUserEmail();
    }
}
