using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Logic.Interfaces;
using Library.Models;
using Library.Repository.Interfaces;
using Library.ViewModels;

namespace Library.Logic
{
  public class UserLogic : IUserLogic
  {
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserLogic(IMapper mapper, IUserRepository userRepository)
    {
      _mapper = mapper;
      _userRepository = userRepository;
    }

    public async Task<UserQueryDto> ReadUser(string userId)
    {
      var model = await _userRepository.ReadUser(userId);
      var result = _mapper.Map<UserQueryDto>(model);

      return result;
    }
  }
}
