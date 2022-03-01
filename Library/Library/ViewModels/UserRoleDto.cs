using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.ViewModels
{
  public class UserRoleCommandDto
  {
    public string UserId { get; set; }
    public int Role { get; set; }
  }
  public class UserRoleQueryDto
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int Role { get; set; }
  }
}
