using Stream.Server.Domain.Commands.Server;
using Stream.Server.Domain.Test.Mocks;
using Xunit;

namespace Stream.Server.Domain.Test.CommandsTests.Server
{
    public class CreateServerCommandTest 
    {
         private readonly CreateServerCommand _invalidCommand = new CreateServerCommand("", "", 0);
         private readonly CreateServerCommand _validCommand   = new CreateServerCommand("Servidor 01", "10.0.0.1", 1090);
        
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
