using AutoMapper;
using BookApp.Application.DTO;
using BookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Mapping.MappingProfile
{
    internal class BookProfile: Profile
    {
        public BookProfile()
        {
            // source -> Target
            CreateMap<CreateBookDTO, Book>();
            CreateMap<BookDTO, Book>().ReverseMap();
        }
    }
}
