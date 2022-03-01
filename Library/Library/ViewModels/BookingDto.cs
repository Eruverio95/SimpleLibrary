using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
  public class BookingCommandDto
  {
    public DateTime BookingDate { get; set; }
    public string UserId { get; set; }
    public int BookId { get; set; }
  }
  public class BookingQueryDto
  {
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public string UserId { get; set; }
    public int BookId { get; set; }
  }
}