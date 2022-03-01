using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
  public class BookCommandDto
  {
    public string Name { get; set; }
    public string Author { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
  }
  public class BookQueryDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
  }
}