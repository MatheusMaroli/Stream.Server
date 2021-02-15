using Stream.Server.Domain.Commands.Contracts;
using Stream.Server.Domain.CommandsBehaviors;
using System;
using Stream.Server.Domain.Helpers;

namespace Stream.Server.Domain.Commands.Server
{
    public class DeleteServerCommand : NotificationValidatorContext, ICommand
    {
        public Guid ServerId { get; set; }

        public DeleteServerCommand() { }
        public DeleteServerCommand(Guid serverId)
        {
            ServerId = serverId;
        }

        public override void Validate()
        {
            if (!ServerId.IsValid())
                AddNotification("Server id invalido");
        }
    }
}
