using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stream.Server.Api.Models
{
    public class ServerPresentation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }

        public ServerPresentation(Guid id, string name, string ip, int port)
        {
            Id = id;
            Name = name;
            Ip = ip;
            Port = port;
        }
    }
}
