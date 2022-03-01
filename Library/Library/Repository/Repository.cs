using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Library.Data;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
  public class Repository<T> : IRepository<T> where T : class
  {
    protected readonly LibraryDbContext set;

    protected readonly DbSet<T> _set;

    public Repository(LibraryDbContext context)
    {
      set = context;
      _set = context.Set<T>();
    }

    public IQueryable<T> Queryable => AsQueryable();

    protected virtual IQueryable<T> AsQueryable()
    {
      return _set.AsQueryable();
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
      return await set.SaveChangesAsync(cancellationToken) > 0;
    }
  }
}
