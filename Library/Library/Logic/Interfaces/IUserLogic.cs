using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.ViewModels;

namespace Library.Logic.Interfaces
{
  public interface IUserLogic
  {
    Task<UserQueryDto> ReadUser(string userId);
  }
}
