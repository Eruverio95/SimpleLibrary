using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Logic.Interfaces
{
  public interface IAuthorizationService
  {
    Task<bool> HaveAdministratorRights(string userId);
  }
}
