using Microsoft.AspNetCore.Mvc;
using Stream.Server.Domain.Commands;

namespace Stream.Server.Api.Helpers
{
    public static class ControllerHelper
    {
        public static IActionResult DefaultCommandResultToActionResult(this Controller _controller, DefaultCommandResult commandResult)
        {
            if (commandResult.IsSuccess)
                return _controller.Ok(commandResult);
            else
                return _controller.BadRequest(commandResult);

        }

        public static IActionResult DefaultCommandResultToAccepted(this Controller _controller, DefaultCommandResult commandResult)
        {
            if (commandResult.IsSuccess)
                return _controller.Accepted(commandResult);
            else
                return _controller.BadRequest(commandResult);

        }

        public static IActionResult FileCommandResultToActionResult(this Controller _controller, FileCommandResult commandResult)
        {            
            if (commandResult.IsSuccess)
            {
                var video = (Domain.Entities.Video)commandResult.Data;
                return new FileContentResult(commandResult.File.ToArray(), "application/octet-stream")
                {
                    FileDownloadName = $"{video.FileName}",
                };            }                
            else return _controller.BadRequest(commandResult);
        }

         
    }
}
