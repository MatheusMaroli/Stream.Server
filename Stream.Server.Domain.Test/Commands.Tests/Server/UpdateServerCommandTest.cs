using Stream.Server.Domain.Commands.Server;
using System;
using Xunit;

namespace Stream.Server.Domain.Test.Commands.Tests.Server
{
    public class UpdateServerCommandTest
    {
        private readonly UpdateServerCommand _invalidCommand = new UpdateServerCommand(new Guid(), "", "", 0);
        private readonly UpdateServerCommand _validCommand = new UpdateServerCommand(Guid.NewGuid(), "Servidor 01", "10.0.0.1", 1090);

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
