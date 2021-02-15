using Stream.Server.Domain.Entities;
using Stream.Server.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Server.Domain.Test.Repositories
{
    public class FakeRecycleRepository : IRecycleRepository
    {
        public Recycle Get()
        {
            return new Recycle(EnumType.RecyclerStatus.NotRunning, new DateTime());
        }

        public void Save(Recycle status)
        {
           //
        }

        public void Update(Recycle status)
        {
            //
        }
    }
}
