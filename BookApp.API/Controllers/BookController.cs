using BookApp.Application.DTO;
using BookApp.Application.Interface;
using BookApp.Application.Utilities.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService service)
        {
            _bookService = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDTO model)
        {
            return ReturnResponse(await _bookService.CreateBook(model));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            return ReturnResponse(await _bookService.DeleteBook(id));
        }

        [HttpPut]
        public async Task<IActionResult> EditBook(BookDTO model)
        {
            return ReturnResponse(await _bookService.EditBook(model));
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetBook(Guid Id)
        {
            return ReturnResponse(await _bookService.GetBook(Id));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery] PagedResponseViewModel model)
        {
            return ReturnResponse(await _bookService.GetAllBooks(model));
        }
    }
}
