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
    public class DeleteServerHandlerTest
    {
        private readonly DeleteServerCommand _invalidCommand;
        private readonly DeleteServerCommand _validCommandWithNotExistsId;
        private readonly DeleteServerCommand _validCommand;
        private ServerHandler _serverHandler;
        private DataContextMock _dataContextMock;

        public DeleteServerHandlerTest()
        {
            _dataContextMock = new DataContextMock();
            _invalidCommand = new DeleteServerCommand(new Guid());
            _validCommandWithNotExistsId = new DeleteServerCommand(Guid.NewGuid());
            var serverSalvedId = _dataContextMock.Servers.FirstOrDefault().Id;
            _validCommand = new DeleteServerCommand(serverSalvedId);
        }


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
        public void Given_A_Valid_Command_Should_Be_Delete_A_Server()
        {
            _serverHandler = new ServerHandler(new FakeServerRepository(_dataContextMock));    
            var handlerResponse = (DefaultCommandResult)_serverHandler.Handle(_validCommand);
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
