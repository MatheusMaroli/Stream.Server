using Stream.Server.Domain.Commands;
using Stream.Server.Domain.Commands.Server;
using Stream.Server.Domain.Handlers;
using Stream.Server.Domain.Test.Mocks;
using Stream.Server.Domain.Test.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Stream.Server.Domain.Test.HandlersTests.Server
{
    public class AvailableServerHandlerTest
    {
        private ServerHandler _serverHandler;
        private DataContextMock _dataContextMock;

        public AvailableServerHandlerTest()
        {
            _dataContextMock = new DataContextMock();           
            
        }

        [Fact]
        public void Given_A_Invalid_Command_Should_Be_Return_A_Invalid_Command_Status()
        {
            _serverHandler = new ServerHandler(new FakeServerRepository(_dataContextMock));
            var invalidCommand = new AvailableServerCommand(new Guid(), "", 0);
            var handlerResponse = (DefaultCommandResult)_serverHandler.Handle(invalidCommand);
            Assert.True(handlerResponse.IsInvalidCommand);
        }


        [Fact]
        public void Given_A_Valid_Command_With_Existless_Server_Id_Should_Be_Return_A_Invalid_Data_Status()
        {
            _serverHandler = new ServerHandler(new FakeServerRepository(_dataContextMock));
            var commandForOnlineServer = new AvailableServerCommand(Guid.NewGuid(), "10.1.1.1", 8080);
            var handlerResponse = (DefaultCommandResult)_serverHandler.Handle(commandForOnlineServer);
            Assert.True(handlerResponse.IsInvalidData);
        }

        [Fact]
        public void Should_Be_Return_A_Online_Server()
        {
            _serverHandler = new ServerHandler(new FakeServerRepository(_dataContextMock));
            var serverMock = _dataContextMock.Servers.FirstOrDefault();
            var commandForOnlineServer = new AvailableServerCommand(serverMock.Id, serverMock.Ip, serverMock.Port);                      

            var handlerResponse = (DefaultCommandResult)_serverHandler.Handle(commandForOnlineServer);
            Assert.True(handlerResponse.IsSuccess);
        }


        [Fact]
        public void Should_Be_Return_A_Offline_Server()
        {
            _serverHandler = new ServerHandler(new FakeServerRepository(_dataContextMock));
            var serverMock = _dataContextMock.Servers.FirstOrDefault();
            var commandForOfflineServer= new AvailableServerCommand(serverMock.Id, "xxxx", 99999);
            var handlerResponse = (DefaultCommandResult)_serverHandler.Handle(commandForOfflineServer);
            Assert.True(handlerResponse.IsInvalidData);
        }

        [Fact]
        public void Should_Be_Exception_Fail()
        {
            _serverHandler = new ServerHandler(new FakeExectionServerRepository());
            var command = new AvailableServerCommand(Guid.NewGuid(), "10.1.1.1", 8080);
            var handlerResponse = (DefaultCommandResult)_serverHandler.Handle(command);
            Assert.True(handlerResponse.IsException);
        }
    }
}
