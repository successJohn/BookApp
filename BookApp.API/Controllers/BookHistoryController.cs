using BookApp.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookApp.Application.Utilities.PermissionProvider;

namespace BookApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookHistoryController : BaseController
    {
        private readonly IBookHistoryService _bookHistoryService;

        public BookHistoryController(IBookHistoryService service)
        {
            _bookHistoryService = service;
        }

        [HttpGet]
        //[Authorize(Policy = nameof(Permission.BOOK_HISTORY))]
        public async Task<IActionResult> GetBookHistory(Guid bookId)
        {
            return ReturnResponse(await _bookHistoryService.GetBookHistory(bookId));
        }

        [HttpPost]
        [Route("Borrow-Book")]
        public async Task<IActionResult> BorrowBook(Guid bookId)
        {
            return ReturnResponse(await _bookHistoryService.BorrowBook(bookId));
        }

        [HttpPost]
        [Route("Return-Book")]
        public async Task<IActionResult> ReturnBook(Guid bookId)
        {
            return ReturnResponse(await _bookHistoryService.ReturnBook(bookId));
        }

    }
}
