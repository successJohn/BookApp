using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Domain.Enums;

namespace BookApp.Domain.Entities
{
    public class BookHistory
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; } // Foreign key to the Book

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

        [ForeignKey(nameof(UserId))]

        public Guid UserId { get; set; }    

        public ApplicationUser User { get; set; }

        public BookStatus Status { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
