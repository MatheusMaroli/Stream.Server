using Microsoft.AspNetCore.Mvc;
using Stream.Server.Domain.Handlers;
using Stream.Server.Domain.Repositories;
using Stream.Server.Api.Helpers;
using Stream.Server.Domain.Commands.Recycle;
using Stream.Server.Domain.Commands;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Stream.Server.Api.Controllers
{
    public class RecyclerController : Controller
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RecyclerController(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        [HttpGet, Route("/api/recycler/status")]
        public IActionResult Status([FromServices] IRecycleRepository repository)
        {
            var status = repository.Get();
            return Ok(RecycleDataPresentation.RecycleToPresentationFormatter(status));
        }

        [HttpPut, Route("/api/recycler/process/{days}")]
        public IActionResult Process([FromRoute] int days)
        {
            var task = Task.Run(() =>
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var handler = scope.ServiceProvider.GetService<RecycleHandler>();
                    return handler.Handle(new RecycleVideoForMoreThenDaysCommand(days));
                };
            });
            return Accepted(RecycleDataPresentation.RecycleToPresentationFormatter(Domain.EnumType.RecyclerStatus.Running));
        }
    }
}
