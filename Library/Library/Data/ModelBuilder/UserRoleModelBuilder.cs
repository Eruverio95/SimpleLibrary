using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.ModelBuilder
{
  public class UserRoleModelBuilder
  {
    public static void Build(Microsoft.EntityFrameworkCore.ModelBuilder builder)
    {
      var entity = builder.Entity<UserRole>();

      entity.ToTable("UserRoles");
      entity.HasKey(k => k.Id);
      entity.Property<int>(p => p.Id).IsRequired().HasColumnName("Id");
      entity.Property<string>(p => p.UserId).IsRequired().HasColumnName("UserId").HasMaxLength(8);
      entity.Property<int>(p => p.Role).IsRequired().HasColumnName("Role");
    }
  }
}
