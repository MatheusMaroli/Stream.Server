using Stream.Server.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Stream.Server.Api.Helpers
{
    public static class ServerDataPresentation
    {
        public static IEnumerable<ServerPresentation> ServerToPresentationFormatter(IEnumerable<Domain.Entities.Server> servers)
        {
            if (! servers.Any())
                return null;
            var list = new List<ServerPresentation>();
            foreach (var server in servers)
                list.Add(ServerToPresentationFormatter(server));
            return list;
        }

        public static ServerPresentation ServerToPresentationFormatter(Domain.Entities.Server server)
        {
            if (server == null)
                return null;
            return new ServerPresentation(server.Id, server.Name, server.Ip, server.Port);
        }
    }
}
