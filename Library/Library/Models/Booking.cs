using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
  public class Booking
  {
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
  }
}