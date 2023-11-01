using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Domain.Entities
{
    public class Book: BaseEntity
    {
        public Guid Id { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int QuantityInStock { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool isAvailable { get; set; } = true;


        public List<BookHistory> BookHistories { get; set; }
    }
}
