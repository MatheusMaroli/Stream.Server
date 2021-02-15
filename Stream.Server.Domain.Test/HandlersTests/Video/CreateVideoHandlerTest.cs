using Stream.Server.Domain.Test.Mocks;
using Stream.Server.Domain.Handlers;
using Xunit;
using Stream.Server.Domain.Test.Repositories;
using Stream.Server.Domain.Commands;
using Stream.Server.Domain.Commands.Video;
using System;
using System.Linq;

namespace Stream.Server.Domain.Test.HandlersTests.Video
{
    public class CreateVideoHandlerTest
    {
        private readonly CreateVideoCommand _invalidCommand;
        private readonly CreateVideoCommand _validCommand; 
        private DataContextMock _dataContextMock = new DataContextMock();
        private FakeServerRepository _fakeServerRepository;
        private FakeVideoRepository _fakeVideoRepository;
        private VideoHandler _videoHandler;
        
        public CreateVideoHandlerTest()
        {
            _fakeServerRepository = new FakeServerRepository(_dataContextMock);
            _fakeVideoRepository = new FakeVideoRepository(_dataContextMock);            
            _invalidCommand = new CreateVideoCommand(new Guid(), "", VideoMock.GetFakeInvalidVideo(), "");
            var serverID = _dataContextMock.Servers.FirstOrDefault();
            _validCommand = new CreateVideoCommand(serverID.Id, "Video 01", VideoMock.GetFakeValidVideo(), "c:");

        }

        [Fact]
        public void Given_A_Invalid_Command_Should_Be_Return_A_Invalid_Command_Status()
        {
            _videoHandler = new VideoHandler(_fakeServerRepository, _fakeVideoRepository);
            var handlerResponse = (DefaultCommandResult)_videoHandler.Handle(_invalidCommand);
            Assert.True(handlerResponse.IsInvalidCommand);
        }

        [Fact]
        public void Given_A_Valid_Command_Should_Be_Create_A_Video()
        {

            _videoHandler = new VideoHandler(_fakeServerRepository, _fakeVideoRepository);
            var handlerResponse = (DefaultCommandResult)_videoHandler.Handle(_validCommand);
            Assert.True(handlerResponse.IsSuccess);
        }

        [Fact]
        public void Should_Be_Exception_Fail()
        {
            _videoHandler = new VideoHandler(_fakeServerRepository,  new FakeExceptionVideoRepository());
            var handlerResponse = (DefaultCommandResult)_videoHandler.Handle(_validCommand);
            Assert.True(handlerResponse.IsException);
        }
    }
}
