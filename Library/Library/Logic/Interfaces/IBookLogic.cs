using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.ViewModels;

namespace Library.Logic.Interfaces
{
  public interface IBookLogic
  {
    Task<BookQueryDto> CreateBook(BookCommandDto viewModel);
    Task<BookQueryDto> ReadBook(int bookId);
    Task<IList<BookQueryDto>> ReadBooks();
    Task<BookQueryDto> UpdateBook(int bookId, BookCommandDto viewModel);
    Task<BookingQueryDto> ToBookABook(BookingCommandDto viewModel);
    Task<IList<BookingQueryDto>> BookingOfUser(string userId);
    Task<IList<BookingQueryDto>> BookingOfBook(int bookId);

    Task<IList<BookingQueryDto>> BookingOfAll();
  }
}
