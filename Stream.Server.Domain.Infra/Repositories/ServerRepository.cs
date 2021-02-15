using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Stream.Server.Domain.Infra.Contexts;
using Stream.Server.Domain.Queries;
using Stream.Server.Domain.Repositories;

namespace Stream.Server.Domain.Infra.Repositories
{
    public class ServerRepository : BaseRepository, IServerRepository
    {
        public ServerRepository(DataContext context) : base(context)
        {
        }

        public void Delete(Entities.Server server)
        {
            _dataContext.Servers.Remove(server);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Entities.Server> GetAll()
        {
            return _dataContext.Servers.AsNoTracking().ToList();
        }

        public Entities.Server GetById(Guid Id)
        {
            return _dataContext.Servers.AsNoTracking().FirstOrDefault(ServerQueries.GetById(Id));
        }


        public void Save(Entities.Server server)
        {
            _dataContext.Servers.Add(server);
            _dataContext.SaveChanges();
        }

        public void Update(Entities.Server server)
        {
            _dataContext.Entry(server).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}
