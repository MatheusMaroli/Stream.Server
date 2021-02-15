using Stream.Server.Domain.Commands;
using Stream.Server.Domain.Commands.Contracts;
using Stream.Server.Domain.Commands.Server;
using Stream.Server.Domain.Handlers.Contracts;
using Stream.Server.Domain.EnumType;
using System;
using Stream.Server.Domain.Repositories;

namespace Stream.Server.Domain.Handlers
{
    public class ServerHandler : IHandler<CreateServerCommand>,
                                 IHandler<UpdateServerCommand>,
                                 IHandler<DeleteServerCommand>,
                                 IHandler<AvailableServerCommand>
    {
        private readonly IServerRepository _serverRepository;

        public ServerHandler(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public ICommandResult Handle(CreateServerCommand command)
        {
            command.Validate();
            if (command.IsInvalid)
            {
                return new DefaultCommandResult(CommandResultStatus.InvalidCommand, command.Notifications);
            }

            try
            {
                var server = new Entities.Server()
                {
                    Name = command.Name,
                    Ip = command.Ip,
                    Port = command.Port
                };
                _serverRepository.Save(server);
                return new DefaultCommandResult(server.Id);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Fail to execute CreateServerHandler. Fail stack ===> {e.ToString()}");
                return new DefaultCommandResult(CommandResultStatus.Exception);

            }
        }

        public ICommandResult Handle(UpdateServerCommand command)
        {
            command.Validate();
            if (command.IsInvalid)
            {
                return new DefaultCommandResult(CommandResultStatus.InvalidCommand, command.Notifications);
            }

            try
            {
                var server = _serverRepository.GetById(command.Id);
                if (server == null)
                    return new DefaultCommandResult(CommandResultStatus.InvalidData, "Nenhum servidor foi localizado");

                server.Name = command.Name;
                server.Ip = command.Ip;
                server.Port = command.Port;
                _serverRepository.Update(server);
                return new DefaultCommandResult(server.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fail to execute UpdateServerHandler. Fail stack ===> {e.ToString()}");
                return new DefaultCommandResult(CommandResultStatus.Exception);

            }
        }

        public ICommandResult Handle(DeleteServerCommand command)
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
                    return new DefaultCommandResult(CommandResultStatus.InvalidData, "Nenhum servidor foi localizado");

                
                _serverRepository.Delete(server);
                return new DefaultCommandResult(server.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fail to execute DeleteServerHandler. Fail stack ===> {e.ToString()}");
                return new DefaultCommandResult(CommandResultStatus.Exception);

            }
        }

        public ICommandResult Handle(AvailableServerCommand command)
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
                    return new DefaultCommandResult(CommandResultStatus.InvalidData, "Nenhum servidor foi localizado");

                if (server.ResponseInIPAndPort(command.Ip, command.Port))
                    return new DefaultCommandResult(CommandResultStatus.Success, "Servidor online");


                return new DefaultCommandResult(CommandResultStatus.InvalidData, "Servidor offiline");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fail to execute AvailableServerHandler. Fail stack ===> {e.ToString()}");
                return new DefaultCommandResult(CommandResultStatus.Exception);

            }
        }
    }
}
