using System;
using System.Collections.Generic;
using System.Text;
using Stream.Server.Domain.Commands;
using Stream.Server.Domain.Commands.Recycle;
using Stream.Server.Domain.Handlers;
using Stream.Server.Domain.Test.Mocks;
using Stream.Server.Domain.Test.Repositories;
using Xunit;

namespace Stream.Server.Domain.Test.HandlersTests.Recycle
{
    public class RecycleVideoForMoreThenDaysHandlerTest
    {
        private readonly RecycleVideoForMoreThenDaysCommand _invalidCommand = new RecycleVideoForMoreThenDaysCommand(-1);
        private readonly RecycleVideoForMoreThenDaysCommand _validCommand = new RecycleVideoForMoreThenDaysCommand(0);
        private RecycleHandler _recycleHandler;
        private DataContextMock _dataContextMock = new DataContextMock();

        [Fact]
        public void Given_A_Invalid_Command_Should_Be_Return_A_Invalid_Command_Status()
        {
            _recycleHandler = new RecycleHandler(new FakeRecycleRepository(), new FakeVideoRepository(_dataContextMock));
            var handlerResponse = (DefaultCommandResult)_recycleHandler.Handle(_invalidCommand);
            Assert.True(handlerResponse.IsInvalidCommand);
        }

        [Fact]
        public void Given_A_Valid_Command_Should_Be_Success_Status()
        {
            _recycleHandler = new RecycleHandler(new FakeRecycleRepository(), new FakeVideoRepository(_dataContextMock));
            var handlerResponse = (DefaultCommandResult)_recycleHandler.Handle(_validCommand);
            Assert.True(handlerResponse.IsSuccess);
        }

        [Fact]
        public void Should_Be_Exception_Fail()
        {
            _recycleHandler = new RecycleHandler(new FakeExceptionRecycleRepository(), new FakeExceptionVideoRepository());
            var handlerResponse = (DefaultCommandResult)_recycleHandler.Handle(_validCommand);
            Assert.True(handlerResponse.IsException);
        }

    }
}
