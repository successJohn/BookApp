using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Domain.Enums
{
    public enum BookStatus
    {
        [Description("Issued")]
        Issued,
        [Description("Returned")]
        Returned
    }
}
