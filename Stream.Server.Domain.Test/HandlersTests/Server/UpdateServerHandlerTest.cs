using Stream.Server.Domain.Commands;
using Stream.Server.Domain.Commands.Server;
using Stream.Server.Domain.Handlers;
using Stream.Server.Domain.Test.Mocks;
using Stream.Server.Domain.Test.Repositories;
using System;
using System.Linq;
using Xunit;

namespace Stream.Server.Domain.Test.HandlersTests.Server
{
    public class UpdateServerHandlerTest
    {
        private readonly UpdateServerCommand _invalidCommand = new UpdateServerCommand(new Guid(), "", "", 0);
        private readonly UpdateServerCommand _validCommand = new UpdateServerCommand(Guid.NewGuid(), "Servidor 1", "10.1.1.1", 1);    
        private readonly UpdateServerCommand _validCommandWithNotExistsId = new UpdateServerCommand(Guid.NewGuid(), "Servidor 1", "10.1.1.1", 1);
        private ServerHandler _serverHandler;
        private DataContextMock _dataContextMock = new DataContextMock();

        [Fact]
        public void Given_A_Invalid_Command_Should_Be_Return_A_Invalid_Command_Status()
        {
            _serverHandler = new ServerHandler(new FakeServerRepository(_dataContextMock));
            var handlerResponse = (DefaultCommandResult)_serverHandler.Handle(_invalidCommand);
            Assert.True(handlerResponse.IsInvalidCommand);
        }


        [Fact]
        public void Given_Command_With_Not_Exists_Id_Should_Be_Return_A_Invalid_Data_Status()
        {
            _serverHandler = new ServerHandler(new FakeServerRepository(_dataContextMock));
            var handlerResponse = (DefaultCommandResult)_serverHandler.Handle(_validCommandWithNotExistsId);
            Assert.True(handlerResponse.IsInvalidData);
        }

        [Fact]
        public void Given_A_Valid_Command_Should_Be_Update_A_Server()
        {
            _serverHandler = new ServerHandler(new FakeServerRepository(_dataContextMock));
            var serverSalvedId = _dataContextMock.Servers.FirstOrDefault().Id;
            var commandForUpdate = new UpdateServerCommand()
            {
                Id = serverSalvedId,
                Name = "Updated Server",
                Ip = "10.1.1.15",
                Port = 55
            };
            
            var handlerResponse = (DefaultCommandResult)_serverHandler.Handle(commandForUpdate);
            Assert.True(handlerResponse.IsSuccess);
        }

        [Fact]
        public void Should_Be_Exception_Fail()
        {
            _serverHandler = new ServerHandler(new FakeExectionServerRepository());
            var handlerResponse = (DefaultCommandResult)_serverHandler.Handle(_validCommand);
            Assert.True(handlerResponse.IsException);
        }
    }
}
