using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.DTO
{
    public class BookHistoryDTO
    {
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }

        public int QuantityInStock { get; set; }

        public int QuantityStocked { get; set; }

        public string BorrowedBy { get; set; }

        public DateTime BorrowedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }


    }
}
