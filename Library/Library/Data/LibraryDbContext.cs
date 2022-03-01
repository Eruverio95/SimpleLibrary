using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.ModelBuilder;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
  public class LibraryDbContext : DbContext
  {
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }
    
    private DbSet<Book> Books { get; set; }
    private DbSet<Booking> Bookings { get; set; }
    private DbSet<User> Users { get; set; }
    private DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      
      BookModelBuilder.Build(modelBuilder);
      BookingModelBuilder.Build(modelBuilder);
      UserModelBuilder.Build(modelBuilder);
      UserRoleModelBuilder.Build(modelBuilder);
    }
  }
}
