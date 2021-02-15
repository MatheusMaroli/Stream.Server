using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stream.Server.Domain.Entities
{
    public class Server : BaseEntity
    {
        [Required, MaxLength(500)]
        public string Name { get; set; }
        [Required, MaxLength(250)]
        public string Ip { get; set; }
        [Required] 
        public int Port { get; set; }
        public ICollection<Video> Videos { get; set; }

        public Server() { }
        public Server(Guid id, string name, string ip, int port)
        {
            Id = id;
            Name = name;
            Ip = ip;
            Port = port;
        }

        public bool ResponseInIPAndPort(string ip, int port)
            => Ip == ip && Port == port;
    }
}
