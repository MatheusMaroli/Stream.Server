using Stream.Server.Domain.Commands.Server;
using System;
using Xunit;

namespace Stream.Server.Domain.Test.Commands.Tests.Server
{
    public class AvailablServerCommandTest
    {
        private readonly AvailableServerCommand _invalidCommand = new AvailableServerCommand(new Guid(), "",  0);
        private readonly AvailableServerCommand _validCommand = new AvailableServerCommand(Guid.NewGuid(), "10.0.0.1", 1090);

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
