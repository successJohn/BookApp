using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.DTO
{
    public class BookDTO
    {
        public Guid BookId { get; set; }
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int QuantityInStock { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool isAvailable { get; set; } = true;
    }
}
