using Stream.Server.Domain.Commands.Contracts;

namespace Stream.Server.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
