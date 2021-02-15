using Stream.Server.Domain.Entities;
using Stream.Server.Domain.Repositories;
using System;

namespace Stream.Server.Domain.Test.Repositories
{
    public class FakeExceptionRecycleRepository : IRecycleRepository
    {
        public Recycle Get()
        {
            throw new Exception("Force Exception");
        }

        public void Save(Recycle status)
        {
            throw new Exception("Force Exception");
        }

        public void Update(Recycle status)
        {
            throw new Exception("Force Exception");
        }
    }
}
