using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.DTO
{
    public class BorrowBookDTO
    {
        public Guid BookId { get; set; }

        public DateTime ExpectedReturnDate { get; set; }
    }
}
