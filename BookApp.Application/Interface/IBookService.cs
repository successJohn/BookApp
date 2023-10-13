using BookApp.Application.DTO;
using BookApp.Application.Utilities;
using BookApp.Application.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Interface
{
    public interface IBookService
    {
         Task<BaseResponse<Guid>> CreateBook(CreateBookDTO model);
        Task<BaseResponse<Guid>> DeleteBook(Guid BookId);
        Task<BaseResponse<Guid>> EditBook(BookDTO model);
        Task<BaseResponse<BookDTO>> GetBook(Guid BookId);

        Task<BaseResponse<PagedList<BookDTO>>> GetAllBooks(PagedResponseViewModel model);
    }
}
