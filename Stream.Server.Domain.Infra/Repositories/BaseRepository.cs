using Stream.Server.Domain.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Server.Domain.Infra.Repositories
{
    public abstract class BaseRepository
    {
        protected DataContext _dataContext;
        public BaseRepository(DataContext context)
        {
            _dataContext = context;
        }
    }
}
