using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.ViewModels;

namespace Library.Repository.Interfaces
{
  public interface IBookRepository
  {
    Task<Book> CreateBook(Book model);
    Task<Book> ReadBook(int bookId);
    Task<IList<Book>> ReadBooks();
    Task UpdateBook();
  }
}
