using System;
using System.Collections.Generic;

namespace Stream.Server.Domain.Repositories
{
    public interface IServerRepository
    {
        void Save(Entities.Server server);
        void Update(Entities.Server server);
        void Delete(Entities.Server server);
        Entities.Server GetById(Guid Id);
        //Entities.Server GetByIpAndPort(string ip, int port);//alter
        IEnumerable<Entities.Server> GetAll();
    }
}
