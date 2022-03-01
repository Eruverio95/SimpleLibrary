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
  public class BookingRepository : Repository<Booking>, IBookingRepository
  {
    public BookingRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<Booking> ToBookABook(Booking model)
    {
      var result = await _set.AddAsync(model);

      if (!await SaveChangesAsync())
      {
        throw new Exception("Could not book a book!");
      }

      return result.Entity;
    }

    public async Task<IList<Booking>> BookingOfUser(string userId)
    {
      var result = await AsQueryable().Where(x => x.UserId.Equals(userId)).ToListAsync();

      return result;
    }

    public async Task<IList<Booking>> BookingOfBook(int bookId)
    {
      var result = await AsQueryable().Where(x => x.BookId == bookId).ToListAsync();

      return result;
    }

    public async Task<IList<Booking>> BookingOfAll()
    {
      var result = await AsQueryable().ToListAsync();

      return result;
    }
  }
}
