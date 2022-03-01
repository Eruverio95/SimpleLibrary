using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.ModelBuilder
{
  public class BookingModelBuilder
  {
    public static void Build(Microsoft.EntityFrameworkCore.ModelBuilder builder)
    {
      var entity = builder.Entity<Booking>();

      entity.ToTable("Bookings");
      entity.HasKey(k => k.Id);
      entity.Property<int>(p => p.Id).IsRequired().HasColumnName("Id");
      entity.Property<DateTime>(p => p.BookingDate).IsRequired().HasColumnName("BookingDate").HasColumnType("datetime");
      entity.Property<string>(p => p.UserId).IsRequired().HasColumnName("UserId").HasMaxLength(8);
      entity.Property<int>(p => p.BookId).IsRequired().HasColumnName("BookId");
    }
  }
}
