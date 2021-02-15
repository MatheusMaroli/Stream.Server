using Stream.Server.Domain.Commands.Contracts;
using Stream.Server.Domain.CommandsBehaviors;
using Stream.Server.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Server.Domain.Commands.Video
{
    public class CreateVideoCommand : NotificationValidatorContext, ICommand
    {

        public Guid ServerId { get; set; }
        public string Description { get; set; }       
        public byte[] VideoContent { get; set; }
        public string FileSystemPath { get; set; }

        public CreateVideoCommand()
        {

        }
        /*
        public CreateVideoCommand(Guid serverId, string description, byte[] videoContent)
        {
            ServerId = serverId;
            Description = description;
            VideoContent = videoContent;
        }*/

        public CreateVideoCommand(Guid serverId, string description, byte[] videoContent, string fileSystemPath)
        {
            ServerId = serverId;
            Description = description;
            VideoContent = videoContent;
            FileSystemPath = fileSystemPath;
        }


        public override void Validate()
        {
            if (!ServerId.IsValid())
                AddNotification("Servidor invalido");

            if (string.IsNullOrEmpty(Description))
                AddNotification("Descrição não foi informada");

            if (string.IsNullOrEmpty(FileSystemPath))
                AddNotification("Local de salvamento do arquivo não foi informado");

            if (VideoContent == null)
                AddNotification("Video não foi informado");
            else if (Buffer.ByteLength(VideoContent) <= 0)
                AddNotification("Video não foi informado");
        }
    }
}
