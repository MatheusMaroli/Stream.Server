using Stream.Server.Domain.Commands.Video;
using Stream.Server.Domain.Test.Mocks;
using System;
using Xunit;

namespace Stream.Server.Domain.Test.Commands.Tests.Video
{
    public class CreateVideoCommandTest
    {


        [Fact]
        public void Should_Be_Invalid_Command()
        {
            var _invalidCommand = new CreateVideoCommand(new Guid(), "", VideoMock.GetFakeInvalidVideo(), "");
            _invalidCommand.Validate();
            Assert.True(_invalidCommand.IsInvalid);
        }

        [Fact]
        public void Should_Be_Valid_Command()
        {
            var _validCommand = new CreateVideoCommand(Guid.NewGuid(), "Video 1", VideoMock.GetFakeValidVideo(), "c:");
            _validCommand.Validate();
            Assert.True(! _validCommand.IsInvalid);
        }
    }
}
