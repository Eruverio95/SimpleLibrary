using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Models;
using Library.ViewModels;

namespace Library.Mapper
{
  public class Mapper : Profile
  {
    public Mapper()
    {
      CreateMap<Book, BookQueryDto>();
      CreateMap<BookCommandDto, Book>();
      CreateMap<Booking, BookingQueryDto>();
      CreateMap<BookingCommandDto, Booking>();
      CreateMap<User, UserQueryDto>();
      CreateMap<UserCommandDto, User>();
      CreateMap<UserRole, UserRoleQueryDto>();
      CreateMap<UserRoleCommandDto, UserRole>();
      //addchange
    }
  }
}
