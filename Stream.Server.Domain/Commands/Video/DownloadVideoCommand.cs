using Stream.Server.Domain.Commands.Contracts;
using Stream.Server.Domain.CommandsBehaviors;
using Stream.Server.Domain.Helpers;
using System;

namespace Stream.Server.Domain.Commands.Video
{
    public class DownloadVideoCommand : NotificationValidatorContext, ICommand
    {
        public Guid ServerId { get; set; }
        public Guid VideoId { get; set; }

        public DownloadVideoCommand() { }
        public DownloadVideoCommand(Guid serverId, Guid videoId)
        {
            ServerId = serverId;
            VideoId = videoId;
        }

        public override void Validate()
        {
            if (!ServerId.IsValid())
                AddNotification("Servidor invalido");

            if (!VideoId.IsValid())
                AddNotification("Video invalido");
        }
    }
}
