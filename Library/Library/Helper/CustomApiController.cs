using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Library.Helper
{
  public class CustomApiController : ControllerBase
  {
    private string _userName;

    public string UserName
    {
      get
      {
        if (string.IsNullOrEmpty(_userName))
        {
          var s = User.Identity.Name.Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
          _userName = s[s.Length - 1];
        }

        return _userName.ToUpper();
      }
    }
  }
}
