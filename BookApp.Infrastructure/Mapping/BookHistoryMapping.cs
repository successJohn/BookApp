using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Mapping
{
    public class BookHistoryMapping: IEntityTypeConfiguration<BookHistory>
    {
        public void Configure(EntityTypeBuilder<BookHistory> builder)
        {
            builder
                .HasOne(x => x.Book)
                .WithMany(x => x.BookHistories)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.NoAction);


            
        }
    }
}
