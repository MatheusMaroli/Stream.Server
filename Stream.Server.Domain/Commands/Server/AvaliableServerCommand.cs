using Stream.Server.Domain.Commands.Contracts;
using Stream.Server.Domain.CommandsBehaviors;
using Stream.Server.Domain.Helpers;
using System;

namespace Stream.Server.Domain.Commands.Server
{
    public  class AvailableServerCommand : NotificationValidatorContext, ICommand
    {
        public Guid ServerId { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }

        public AvailableServerCommand() { }
        public AvailableServerCommand(Guid serverId, string ip, int port)
        {
            ServerId = serverId;
            Ip = ip;
            Port = port;
        }

        public override void Validate()
        {
            if (!ServerId.IsValid())
                AddNotification("Servidor invalido");

            if (string.IsNullOrEmpty(Ip))
                AddNotification("Ip não informado");

            if (Port <= 0)
                AddNotification("Porta invalida");
        }
    }
}
