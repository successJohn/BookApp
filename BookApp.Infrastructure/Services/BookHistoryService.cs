using BookApp.Application.DTO;
using BookApp.Application.Interface;
using BookApp.Application.Utilities;
using BookApp.Domain.Entities;
using BookApp.Domain.Enums;
using BookApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Services
{
    public class BookHistoryService : IBookHistoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IContextAccessor _contextAccessor;

        public BookHistoryService(ApplicationDbContext context, IContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        
        public async Task<BaseResponse<BorrowBookDTO>> BorrowBook(Guid BookId)
        {
            var book = await _context.Books.FindAsync(BookId);
            var userId = Guid.Parse( _contextAccessor.GetCurrentUserId());

            if(book is null)
            {
                return new BaseResponse<BorrowBookDTO>("Book cannot be found");
            }

            //check if user already has more than 3 borrowed books without returning

            var booksBorrowed = await _context.BookHistories.Where(x => x.UserId == userId && x.ReturnDate == null).CountAsync();

            if(booksBorrowed > 3) {

                return new BaseResponse<BorrowBookDTO>($"User with Id{userId} Cannot Borrow more than 3 books at once. Return Books to borrow new Ones");
            }
            // check if book already exists with customer : TCan't give the same book twice to a customer if the book hasn't been returned

            var bookHistory = await IfBookWithCustomer(Guid.NewGuid(), BookId);

            if (bookHistory != null)
            {
                return new BaseResponse<BorrowBookDTO>($"Book with Id{BookId} is already borrowed by user");
            }

            if(book.QuantityInStock == 0)
            {
                return new BaseResponse<BorrowBookDTO>($"Book with Id {BookId} Not in stock");
            }

            var borrowedBook = new BookHistory()
            {
                Id = Guid.NewGuid(),
                BookId = BookId,
                UserId = userId,
                CheckOutDate = DateTime.Now,
                ExpectedReturnDate = DateTimeUtils.GetBookReturnDate(DateTime.Now, 21)
            };

            await _context.BookHistories.AddAsync(borrowedBook);

            book.QuantityInStock--;

             _context.Books.Update(book);

            await _context.SaveChangesAsync();

            return new BaseResponse<BorrowBookDTO>(new BorrowBookDTO { BookId = borrowedBook.Id, ExpectedReturnDate = borrowedBook.ExpectedReturnDate }, "Book Issued Successfully");
        }

        public async Task<BaseResponse<string>> ReturnBook(Guid BookId)
        {

            var userId = Guid.Parse(_contextAccessor.GetCurrentUserId());
            var book = await _context.Books.FindAsync(BookId);

            if (book == null)
            {
                return new BaseResponse<string>($"Book with Id {BookId} does not exist");
            }

            var bookHistory = await IfBookWithCustomer(userId, BookId);

            if (bookHistory == null)
            {
                return new BaseResponse<string>($"Book with Id {BookId} not issued to customer");
            }

            bookHistory.ReturnDate = DateTime.Now;
            bookHistory.Status = BookStatus.Returned;

            _context.BookHistories.Update(bookHistory);

            book.QuantityInStock++;

            _context.Books.Update(book);

            await _context.SaveChangesAsync();

            return new BaseResponse<string> { Data = "Thank you. You can check other books" };
        }

        public async Task<BaseResponse<List<BookHistoryDTO>>> GetBookHistory(Guid bookId)
        {
            var book = _context.BookHistories.Where(x => x.BookId == bookId).FirstOrDefault();

            if(book is null)
            {
                return new BaseResponse<List<BookHistoryDTO>>($"Book with Id {bookId} does not have any borrow history");
            }

            var bookHistory = await _context.BookHistories.Where(x => x.BookId == bookId)
                .Include(b => b.Book)
                .Include(u => u.User)
                .Select(c => new BookHistoryDTO
                {
                    BookTitle = c.Book.Title,
                    BookAuthor = c.Book.Author,
                    QuantityInStock = c.Book.QuantityInStock,
                    QuantityStocked = c.Book.Quantity,
                    BorrowedBy = $"{c.User.FirstName} {c.User.LastName}",
                    BorrowedDate = c.CheckOutDate,
                    ReturnedDate = c.ReturnDate
                }).ToListAsync();


            return new BaseResponse<List<BookHistoryDTO>>(bookHistory, "Book successfully retrieved");

        }                     


        private async Task<BookHistory> IfBookWithCustomer(Guid userId, Guid bookId)
        {
            return await _context.BookHistories.Where(x => x.BookId == bookId && x.UserId == userId && x.Status == BookStatus.Issued).FirstOrDefaultAsync();
        }

        //TOD0

        // Check for overdue books and notify users via email
        // public async Task CheckOverdueBooks()
        


    }
}
