using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Stream.Server.Domain.Queries
{
    public static class ServerQueries
    {
        public static Expression<Func<Entities.Server, bool>> GetById(Guid id)
        {
            return server => server.Id == id;
        }

    }
}
