using Microsoft.AspNetCore.Mvc;
using Stream.Server.Api.Helpers;
using Stream.Server.Domain.Commands;
using Stream.Server.Domain.Commands.Video;
using Stream.Server.Domain.Handlers;
using Stream.Server.Domain.Repositories;
using System;
using System.Net.Mime;

namespace Stream.Server.Api.Controllers
{
    public class VideoController : Controller
    {
        [HttpGet, Route("/api/servers/{serverId}/videos")]
        public IActionResult GetServerVideos([FromServices] IVideoRepository repository, [FromRoute] Guid serverId)
        {
            var videos = repository.GetByServerId(serverId);
            return Ok(VideoDataPresentation.VideoToPresentationFormatter(videos));
        }

        [HttpGet, Route("/api/servers/{serverId}/videos/{videoId}")]
        public IActionResult GetVideo([FromServices] IVideoRepository repository, [FromRoute] Guid serverId, [FromRoute] Guid videoId)
        {
            var video = repository.GetByServerIdAndVideoId(serverId, videoId);
            return Ok(VideoDataPresentation.VideoToPresentationFormatter(video));
        }

        [HttpGet, Route("/api/servers/{serverId}/videos/{videoId}/binary")]
        public IActionResult Download([FromServices] VideoHandler handler, [FromRoute] Guid serverId, [FromRoute] Guid videoId)
        {
            var response = (FileCommandResult) handler.Handle(new DownloadVideoCommand(serverId, videoId));
            return this.FileCommandResultToActionResult(response);
        }

        [HttpPost, Route("/api/servers/{serverId}/videos")]
        public IActionResult Create([FromServices] VideoHandler handler, [FromRoute]Guid serverId, [FromBody] CreateVideoCommand command)
        {
            command.ServerId = serverId;
            command.FileSystemPath = AppFileSystem.VideosPath;
            var response = (DefaultCommandResult)handler.Handle(command);
            return this.DefaultCommandResultToActionResult(response);
        }

        [HttpDelete, Route("/api/servers/{serverId}/videos/{videoId}")]
        public IActionResult Delete([FromServices] VideoHandler handler, [FromRoute] Guid serverId, [FromRoute] Guid videoId)
        {
            var command = new DeleteVideoCommand(serverId, videoId);
            var response = (DefaultCommandResult)handler.Handle(command);
            return this.DefaultCommandResultToActionResult(response);
        }
    }
}
