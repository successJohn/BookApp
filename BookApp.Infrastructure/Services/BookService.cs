﻿using AutoMapper;
using BookApp.Application.DTO;
using BookApp.Application.Interface;
using BookApp.Application.Utilities;
using BookApp.Domain.Entities;
using BookApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Services
{
    public class BookService: IBookService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookService(ApplicationDbContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Guid>> CreateBook(CreateBookDTO model)
        {
            var book = _mapper.Map<Book>(model);
            book.Id = new Guid();
            book.CreatedOn = DateTime.Now;
            book.ModifiedOn = DateTime.Now;

           await _context.Books.AddAsync(book);
           await  _context.SaveChangesAsync();

            return new BaseResponse<Guid>( book.Id,"Created Successfully");
        }


        public async Task<BaseResponse<Guid>> DeleteBook(Guid BookId)
        {
            var book = await _context.Books.FindAsync(BookId);
            if(book == null)
            {
                return new BaseResponse<Guid>($"Book with Id {BookId} does not exist");
            }
           
          
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return new BaseResponse<Guid>(book.Id, "Book Deleted Successfully");
        }

        public async Task<BaseResponse<BookDTO>> GetBook(Guid BookId)
        {
            var findBook = await _context.Books.FindAsync(BookId);
            if (findBook == null)
            {
                return new BaseResponse<BookDTO>($"Book with Id {BookId} does not exist");
            }

            var  book = _mapper.Map<BookDTO>(findBook);

            return new BaseResponse<BookDTO>(book, "Book Found Successfully");
        }

        public async Task<BaseResponse<Guid>> EditBook(BookDTO model)
        {
            var book = await _context.Books.FindAsync(model.BookId);
            if (book == null)
            {
                return new BaseResponse<Guid>($"Book with Id {model.BookId} does not exist");
            }

            book.ModifiedOn = DateTime.Now;
            book.Title = model.Title is null ? book.Title : model.Title;
            book.ISBN = model.ISBN is null ? book.ISBN : model.ISBN;
            book.Author = model.Author is null ? book.Author : model.Author;
            book.Description = model.Description is null ? book.Description : model.Description;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return new BaseResponse<Guid>(book.Id, "Book Updated Successfully");
        }


        public async Task<BaseResponse<List<BookDTO>>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();

            var returnBooks = _mapper.Map<List<BookDTO>>(books);

            return new BaseResponse<List<BookDTO>>(returnBooks);
        }
    }
}
