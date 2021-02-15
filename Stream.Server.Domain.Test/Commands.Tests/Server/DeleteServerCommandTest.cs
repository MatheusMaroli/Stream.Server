using Stream.Server.Domain.Commands.Server;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Stream.Server.Domain.Test.Commands.Tests.Server
{
    public class DeleteServerCommandTest
    {
        private readonly DeleteServerCommand _invalidCommand = new DeleteServerCommand(new Guid());
        private readonly DeleteServerCommand _validCommand = new DeleteServerCommand(Guid.NewGuid());

        [Fact]
        public void Should_Be_Invalid_Command()
        {
            _invalidCommand.Validate();
            Assert.True(_invalidCommand.IsInvalid);
        }

        [Fact]
        public void Should_Be_Valid_Command()
        {
            _validCommand.Validate();
            Assert.True(!_validCommand.IsInvalid);
        }
    }
}
