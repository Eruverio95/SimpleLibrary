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
  public class UserRepository : Repository<User>, IUserRepository
  {
    public UserRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<User> ReadUser(string userId)
    {
      var result = await AsQueryable().FirstAsync(x => x.Id.Equals(userId));

      return result;
    }
  }
}
