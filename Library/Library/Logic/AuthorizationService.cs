using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Logic.Interfaces;
using Library.Repository.Interfaces;

namespace Library.Logic
{
  public class AuthorizationService : IAuthorizationService
  {
    private readonly IUserRoleRepository _userRoleRepository;

    public AuthorizationService(IUserRoleRepository userRoleRepository)
    {
      _userRoleRepository = userRoleRepository;
    }

    public async Task<bool> HaveAdministratorRights(string userId)
    {
      var result = await _userRoleRepository.Is(userId);

      return result;
    }
  }
}
