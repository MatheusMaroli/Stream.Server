using Stream.Server.Domain.Commands.Server;
using Stream.Server.Domain.Commands;
using Stream.Server.Domain.Handlers;
using Stream.Server.Domain.Test.Repositories;
using Xunit;
using Stream.Server.Domain.Test.Mocks;

namespace Stream.Server.Domain.Test.HandlersTests.Server
{
    public class CreateServerHandlerTest
    {
        private readonly CreateServerCommand _invalidCommand = new CreateServerCommand("", "", 0);
        private readonly CreateServerCommand _validCommand = new CreateServerCommand("Servidor 01", "10.0.0.1", 1090);
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
        public void Given_A_Valid_Command_Should_Be_Create_A_Server()
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
