using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
  public class BookRepository : Repository<Book>, IBookRepository
  {
    public BookRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<Book> CreateBook(Book model)
    {
      var result = await _set.AddAsync(model);

      if (!await SaveChangesAsync())
      {
        throw new Exception("Could not create new user!");
      }

      return result.Entity;
    }

    public async Task<Book> ReadBook(int bookId)
    {
      var result = await AsQueryable().FirstAsync(x => x.Id == bookId);

      return result;
    }

    public async Task<IList<Book>> ReadBooks()
    {
      var result = await AsQueryable().ToListAsync();

      return result;
    }

    public async Task UpdateBook()
    {
      if (!await SaveChangesAsync())
      {
        throw new Exception("Could not update book!");
      }
    }
  }
}
