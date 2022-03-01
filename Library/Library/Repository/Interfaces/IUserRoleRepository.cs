using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository.Interfaces
{
  public interface IUserRoleRepository
  {
    Task<bool> Is(string userId);
  }
}
