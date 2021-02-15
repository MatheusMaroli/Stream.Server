using Stream.Server.Domain.Commands.Contracts;
using Stream.Server.Domain.CommandsBehaviors;
using Stream.Server.Domain.Helpers;
using System;


namespace Stream.Server.Domain.Commands.Server
{
    public class UpdateServerCommand : NotificationValidatorContext, ICommand
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }

        public UpdateServerCommand() { }
        public UpdateServerCommand(Guid id, string name, string ip, int port)
        {
            Id = id;
            Name = name;
            Ip = ip;
            Port = port;
        }


        public override void Validate()
        {
            if (!Id.IsValid())
                AddNotification("Id invalido");
            if (string.IsNullOrEmpty(Name))
                AddNotification("Nome do servidor não foi informado");
            if (string.IsNullOrEmpty(Ip))
                AddNotification("Ip do servidor não foi informado");
            if (Port == 0)
                AddNotification("Porta do servidor não foi informado");
        }
    }
}
