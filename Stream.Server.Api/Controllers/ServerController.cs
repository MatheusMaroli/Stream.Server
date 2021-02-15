using Microsoft.AspNetCore.Mvc;
using Stream.Server.Domain.Commands;
using Stream.Server.Domain.Commands.Server;
using Stream.Server.Domain.Handlers;
using Stream.Server.Api.Helpers;
using System;
using Stream.Server.Domain.Repositories;

namespace Stream.Server.Api.Controllers
{
    public class ServerController : Controller
    {

        [HttpGet, Route("api/server")]
        public IActionResult GetServers([FromServices] IServerRepository repository)
        {
            var servers = repository.GetAll();
            return Ok(ServerDataPresentation.ServerToPresentationFormatter(servers));
        }   

        [HttpGet, Route("api/server/{serverId}")]
        public IActionResult GetServerById([FromServices] IServerRepository repository, [FromRoute] Guid serverId)
        {
            var server = repository.GetById(serverId);
            return Ok(ServerDataPresentation.ServerToPresentationFormatter(server));
        }

        [HttpGet, Route("api/server/available/{serverId}")]
        public IActionResult Delete([FromServices] ServerHandler handler, [FromRoute] Guid serverId, [FromBody] AvailableServerCommand command)
        {
            command.ServerId = serverId;
            var response = (DefaultCommandResult)handler.Handle(command);
            return this.DefaultCommandResultToActionResult(response);
        }

        [HttpPost, Route("api/server")]
        public IActionResult Create([FromServices]ServerHandler handler, [FromBody] CreateServerCommand command)
        {
            var response = (DefaultCommandResult)handler.Handle(command);
            return this.DefaultCommandResultToActionResult(response);
        }

        [HttpPut, Route("api/server")]
        public IActionResult Update([FromServices] ServerHandler handler, [FromBody] UpdateServerCommand command)
        {
            var response = (DefaultCommandResult)handler.Handle(command);
            return this.DefaultCommandResultToActionResult(response);
        }

        [HttpDelete, Route("api/server/{serverId}")]
        public IActionResult Delete([FromServices] ServerHandler handler, [FromRoute] Guid serverId)
        {
            var command = new DeleteServerCommand(serverId);
            var response = (DefaultCommandResult)handler.Handle(command);
            return this.DefaultCommandResultToActionResult(response);
        }
    }
}
