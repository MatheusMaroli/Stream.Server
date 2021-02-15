using Stream.Server.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Stream.Server.Domain.Test.Repositories
{
    public class FakeExectionServerRepository : IServerRepository
    {
        public void Delete(Entities.Server server)
        {
            throw new Exception("Force fail");
        }

        public IEnumerable<Entities.Server> GetAll()
        {
            throw new Exception("Force fail");
        }

        public Entities.Server GetById(Guid Id)
        {
            throw new Exception("Force fail");
        }

        public void Save(Entities.Server server)
        {
            throw new Exception("Force fail");
        }

        public void Update(Entities.Server server)
        {
            throw new Exception("Force fail");
        }
    }
}
