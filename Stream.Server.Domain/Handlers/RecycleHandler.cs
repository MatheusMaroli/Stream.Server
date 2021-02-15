using Stream.Server.Domain.Commands;
using Stream.Server.Domain.Commands.Contracts;
using Stream.Server.Domain.Commands.Recycle;
using Stream.Server.Domain.EnumType;
using Stream.Server.Domain.Handlers.Contracts;
using Stream.Server.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stream.Server.Domain.Handlers
{
    public class RecycleHandler : IHandler<RecycleVideoForMoreThenDaysCommand>
    {
        private readonly IRecycleRepository _recycleRepository;
        private IVideoRepository _videoRepository;

        public RecycleHandler(IRecycleRepository recycleRepository, IVideoRepository videoRepository)
        {
            _recycleRepository = recycleRepository;
            _videoRepository = videoRepository;
        }

        public ICommandResult Handle(RecycleVideoForMoreThenDaysCommand command)
        {
            command.Validate();
            if (command.IsInvalid)
            {
                return new DefaultCommandResult(CommandResultStatus.InvalidCommand, command.Notifications);
            }

            try
            {
                var statusRecycle = _recycleRepository.Get();
                if (statusRecycle == null)
                {
                    statusRecycle = new Entities.Recycle(RecyclerStatus.NotRunning, new DateTime());
                    _recycleRepository.Save(statusRecycle);
                }
                var deleteBeforeDate = DateTime.Now.Subtract(TimeSpan.FromDays(command.Days));               
                var videos = _videoRepository.GetAllBeforeDate(deleteBeforeDate);
                if (videos.Count() > 0)
                {
                    statusRecycle.SetRunning(deleteBeforeDate);
                    _recycleRepository.Update(statusRecycle);
                    
                    try
                    {
                        Thread.Sleep(5000);

                        foreach (var video in videos)
                        {
                            _videoRepository.DeleteInFileSystem(video);
                            _videoRepository.Delete(video);
                        }
                        statusRecycle.StopRunning();
                        _recycleRepository.Update(statusRecycle);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Fail to execute RecycleVideoForMoreThenDaysHandler. Fail stack ===> {e.ToString()}");
                        statusRecycle.StopRunning();
                        _recycleRepository.Update(statusRecycle);
                    }

                }
              

                return new DefaultCommandResult();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fail to execute RecycleVideoForMoreThenDaysHandler. Fail stack ===> {e.ToString()}");
                return new DefaultCommandResult(CommandResultStatus.Exception);

            }
        }
    }
}
