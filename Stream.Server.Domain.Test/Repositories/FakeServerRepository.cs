using Stream.Server.Domain.Repositories;
using Stream.Server.Domain.Test.Mocks;
using System;
using System.Linq;
using Stream.Server.Domain.Queries;
using System.Collections.Generic;

namespace Stream.Server.Domain.Test.Repositories
{
    public class FakeServerRepository : IServerRepository
    {
        private DataContextMock _dataContext;

        public FakeServerRepository(DataContextMock dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(Entities.Server server)
        {
            //nothing
        }

        public IEnumerable<Entities.Server> GetAll()
        {
            return _dataContext.Servers.AsQueryable().ToList();
        }

        public Entities.Server GetById(Guid id)
        {
            return _dataContext.Servers.AsQueryable().FirstOrDefault(ServerQueries.GetById(id));
        }

        public void Save(Entities.Server server)
        {
            server.Id = new Guid();
            _dataContext.Servers.Add(server);
        }

        public void Update(Entities.Server server)
        {
            //nothing
        }
    }
}
