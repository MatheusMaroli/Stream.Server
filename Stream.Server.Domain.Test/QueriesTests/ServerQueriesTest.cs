using Stream.Server.Domain.Queries;
using Stream.Server.Domain.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Stream.Server.Domain.Test.QueriesTests
{

    public class ServerQueriesTest
    {
        private List<Entities.Server> _items;

        private readonly DataContextMock _dataContextMock = new DataContextMock();
        public ServerQueriesTest()
        {
            _items = _dataContextMock.Servers;
        }

        [Fact]
        public void Should_Be_Get_by_Id_And_Return_A_Data()
        {
            var serverIdExcept = _items.FirstOrDefault().Id;
            var serverQuery = _items.AsQueryable().FirstOrDefault(ServerQueries.GetById(serverIdExcept));
            Assert.Equal(serverIdExcept, serverQuery.Id);
        }

        [Fact]
        public void Should_Be_Get_by_Id_And_Return_A_Null()
        {
            var serverIdFake = Guid.NewGuid();
            var serverQuery = _items.AsQueryable().FirstOrDefault(ServerQueries.GetById(serverIdFake));
            Assert.True(serverQuery == null);
        }

   
    }
}
