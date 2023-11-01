using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
