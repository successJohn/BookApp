using BookApp.Application.DTO;
using BookApp.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Interface
{
    public interface IBookHistoryService
    {
        Task<BaseResponse<BorrowBookDTO>> BorrowBook(Guid BookId);
        Task<BaseResponse<List<BookHistoryDTO>>> GetBookHistory(Guid bookId);
    }
}
