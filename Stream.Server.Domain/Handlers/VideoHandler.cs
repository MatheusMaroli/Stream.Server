using Stream.Server.Domain.Commands;
using Stream.Server.Domain.Commands.Contracts;
using Stream.Server.Domain.Commands.Video;
using Stream.Server.Domain.Entities;
using Stream.Server.Domain.EnumType;
using Stream.Server.Domain.Handlers.Contracts;
using Stream.Server.Domain.Repositories;
using System;
using System.Linq;

namespace Stream.Server.Domain.Handlers
{
    public class VideoHandler : IHandler<CreateVideoCommand>, 
                                IHandler<DeleteVideoCommand>,
                                IHandler<DownloadVideoCommand>    
    {
        private readonly IServerRepository _serverRepository;
        private IVideoRepository _videoRepository;

        public VideoHandler(IServerRepository serverRepository, IVideoRepository videoRepository)
        {
            _serverRepository = serverRepository;
            _videoRepository = videoRepository;
        }

        public ICommandResult Handle(CreateVideoCommand command)
        {
            command.Validate();
            if (command.IsInvalid)
            {
                return new DefaultCommandResult(CommandResultStatus.InvalidCommand, command.Notifications);
            }
            
            try
            {
                var server = _serverRepository.GetById(command.ServerId);
                if (server == null)
                    return new DefaultCommandResult(CommandResultStatus.InvalidData, "Servidor não localizado");

                var fileName = $"{command.Description}.mp4";
                var video = new Video(command.ServerId, command.Description, command.FileSystemPath, fileName, command.VideoContent.Length);
                _videoRepository.Save(video);
                _videoRepository.SaveInFileSystem(video, command.VideoContent);
                return new DefaultCommandResult(CommandResultStatus.Success, "Video cadastrado com sucesso", video.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fail to execute CreateVideoHandler. Fail stack ===> {e.ToString()}");
                return new DefaultCommandResult(CommandResultStatus.Exception);
            }
        }

        public ICommandResult Handle(DeleteVideoCommand command)
        {
            command.Validate();
            if (command.IsInvalid)
            {
                return new DefaultCommandResult(CommandResultStatus.InvalidCommand, command.Notifications);
            }

            try
            {
                var video = _videoRepository.GetByServerIdAndVideoId(command.ServerId, command.VideoId);
                if (video == null)
                    return new DefaultCommandResult(CommandResultStatus.InvalidData, "Video não foi localizado");

                _videoRepository.Delete(video);
                _videoRepository.DeleteInFileSystem(video);
                return new DefaultCommandResult(CommandResultStatus.Success, "Video excluido com sucesso", null);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fail to execute DeleteVideoHandler. Fail stack ===> {e.ToString()}");
                return new DefaultCommandResult(CommandResultStatus.Exception);
            }
        }

        public ICommandResult Handle(DownloadVideoCommand command)
        {
            command.Validate();
            if (command.IsInvalid)
            {
                return new  FileCommandResult(CommandResultStatus.InvalidCommand, command.Notifications);
            }

            try
            {
                var video = _videoRepository.GetByServerIdAndVideoId(command.ServerId, command.VideoId);
                if (video == null)
                    return new FileCommandResult(CommandResultStatus.InvalidData, "Video não foi localizado");

                var videoStream = _videoRepository.GetInFileSystem(video);
                return new FileCommandResult(video, videoStream);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fail to execute DownloadVideoHandler. Fail stack ===> {e.ToString()}");
                return new FileCommandResult(CommandResultStatus.Exception);
            }
        }
    }
}
