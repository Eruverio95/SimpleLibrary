using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Library.Repository.Interfaces;
using Microsoft.AspNetCore.ResponseCaching.Internal;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
  public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
  {
    public UserRoleRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<bool> Is(string userId)
    {
      var result = await AsQueryable().AnyAsync(x => x.UserId.Equals(userId) && x.Role == 1);

      return result;
    }
  }
}
