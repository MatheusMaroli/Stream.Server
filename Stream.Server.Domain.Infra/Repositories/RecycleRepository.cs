using Microsoft.EntityFrameworkCore;
using Stream.Server.Domain.Entities;
using Stream.Server.Domain.Infra.Contexts;
using Stream.Server.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stream.Server.Domain.Infra.Repositories
{
    public class RecycleRepository : BaseRepository, IRecycleRepository
    {
        public RecycleRepository(DataContext context) : base(context)
        {
        }

        public Recycle Get()
        {
            return _dataContext.Recycles.AsNoTracking().FirstOrDefault();
        }

        public void Save(Recycle status)
        {
            _dataContext.Recycles.Add(status);
            _dataContext.SaveChanges();
        }

        public void Update(Recycle status)
        {
            _dataContext.Entry(status).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}
