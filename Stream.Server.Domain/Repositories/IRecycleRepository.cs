using Stream.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Server.Domain.Repositories
{
    public interface IRecycleRepository 
    {
        Recycle Get();
        void Save(Recycle status);
        void Update(Recycle status);
    }
}
