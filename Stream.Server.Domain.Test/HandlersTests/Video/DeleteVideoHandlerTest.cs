using Stream.Server.Domain.Commands;
using Stream.Server.Domain.Commands.Video;
using Stream.Server.Domain.Handlers;
using Stream.Server.Domain.Test.Mocks;
using Stream.Server.Domain.Test.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Stream.Server.Domain.Test.HandlersTests.Video
{
    public class DeleteVideoHandlerTest
    {
        private readonly DeleteVideoCommand _invalidCommand;
        private readonly DeleteVideoCommand _validCommand;
        private readonly DeleteVideoCommand _validCommandWithNotExistsId;
        private DataContextMock _dataContextMock = new DataContextMock();
        private FakeServerRepository _fakeServerRepository;
        private FakeVideoRepository _fakeVideoRepository;
        private VideoHandler _videoHandler;

        public DeleteVideoHandlerTest()
        {
            _fakeServerRepository = new FakeServerRepository(_dataContextMock);
            _fakeVideoRepository = new FakeVideoRepository(_dataContextMock);
            _invalidCommand = new DeleteVideoCommand(new Guid(), new Guid());
            _validCommandWithNotExistsId = new DeleteVideoCommand(Guid.NewGuid(), Guid.NewGuid());
            var videoValid = _dataContextMock.Videos.FirstOrDefault();
            _validCommand = new DeleteVideoCommand(videoValid.ServerId, videoValid.Id);
        }

        [Fact]
        public void Given_A_Invalid_Command_Should_Be_Return_A_Invalid_Command_Status()
        {
            _videoHandler = new VideoHandler(_fakeServerRepository, _fakeVideoRepository);
            var handlerResponse = (DefaultCommandResult)_videoHandler.Handle(_invalidCommand);
            Assert.True(handlerResponse.IsInvalidCommand);
        }

        [Fact]
        public void Given_Command_With_Not_Exists_Id_Should_Be_Return_A_Invalid_Data_Status()
        {
            _videoHandler = new VideoHandler(_fakeServerRepository, _fakeVideoRepository);
            var handlerResponse = (DefaultCommandResult)_videoHandler.Handle(_validCommandWithNotExistsId);
            Assert.True(handlerResponse.IsInvalidData);
        }


        [Fact]
        public void Given_A_Valid_Command_Should_Be_Delete_A_Video()
        {

            _videoHandler = new VideoHandler(_fakeServerRepository, _fakeVideoRepository);
            var handlerResponse = (DefaultCommandResult)_videoHandler.Handle(_validCommand);
            Assert.True(handlerResponse.IsSuccess);
        }

        [Fact]
        public void Should_Be_Exception_Fail()
        {
            _videoHandler = new VideoHandler(_fakeServerRepository, new FakeExceptionVideoRepository());
            var handlerResponse = (DefaultCommandResult)_videoHandler.Handle(_validCommand);
            Assert.True(handlerResponse.IsException);
        }
    }
}
