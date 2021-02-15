using Stream.Server.Domain.Commands.Video;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Stream.Server.Domain.Test.Commands.Tests.Video
{
    public  class DeleteVideoCommandTest
    {
        [Fact]
        public void Should_Be_Invalid_Command()
        {
            var _invalidCommand = new DeleteVideoCommand(new Guid(), new Guid());
            _invalidCommand.Validate();
            Assert.True(_invalidCommand.IsInvalid);
        }

        [Fact]
        public void Should_Be_Valid_Command()
        {
            var _validCommand = new DeleteVideoCommand(Guid.NewGuid(), Guid.NewGuid());
            _validCommand.Validate();
            Assert.True(! _validCommand.IsInvalid); 
        }
    }
}
