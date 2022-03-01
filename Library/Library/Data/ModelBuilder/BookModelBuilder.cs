using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.ModelBuilder
{
  public class BookModelBuilder
  {
    public static void Build(Microsoft.EntityFrameworkCore.ModelBuilder builder)
    {
      var entity = builder.Entity<Book>();

      entity.ToTable("Books");
      entity.HasKey(k => k.Id);
      entity.Property<int>(p => p.Id).IsRequired().HasColumnName("Id");
      entity.Property<string>(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
      entity.Property<string>(p => p.Author).IsRequired().HasColumnName("Author").HasMaxLength(50);
      entity.Property<DateTime>(p => p.ReleaseDate).IsRequired().HasColumnName("ReleaseDate").HasColumnType("datetime");
      entity.Property<string>(p => p.Description).IsRequired().HasColumnName("Description").HasMaxLength(255);
    }
  }
}
