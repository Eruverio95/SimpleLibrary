using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Repository.Interfaces
{
  public interface IBookingRepository
  {
    Task<Booking> ToBookABook(Booking model);
    Task<IList<Booking>> BookingOfUser(string userId);
    Task<IList<Booking>> BookingOfBook(int bookId);

    Task<IList<Booking>> BookingOfAll();
  }
}
