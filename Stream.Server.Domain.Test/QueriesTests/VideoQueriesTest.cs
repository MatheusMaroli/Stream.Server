using Stream.Server.Domain.Queries;
using Stream.Server.Domain.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Stream.Server.Domain.Test.QueriesTests
{
    public class VideoQueriesTest
    {
        private List<Entities.Video> _items;
        private readonly DataContextMock _dataContextMock = new DataContextMock();

        public VideoQueriesTest()
        {
            _items = _dataContextMock.Videos;
        }

        [Fact]
        public void Should_Be_Get_By_Server_Id_And_Video_Id_And_Return_A_Data()
        {
            var videoExcept = _items.FirstOrDefault();
            var videoQuery = _items.AsQueryable().FirstOrDefault(VideoQueries.GetByServerIdAndVideoId(videoExcept.ServerId, videoExcept.Id));
            Assert.True(videoExcept.Equals(videoQuery));
        }

        [Fact]
        public void Should_Be_Get_By_Server_Id_And_Video_Id_And_Return_A_Null()
        {
            var serverIdFake = Guid.NewGuid();
            var videoIdFake = Guid.NewGuid();
            var videoQuery = _items.AsQueryable().FirstOrDefault(VideoQueries.GetByServerIdAndVideoId(serverIdFake, videoIdFake));
            Assert.True(videoQuery == null);
        }

        [Fact]
        public void Should_Be_Get_By_Server_Id_And_Return_A_Data()
        {
            var videoExcept = _items.FirstOrDefault();
            var videoQuery = _items.AsQueryable().Where(VideoQueries.GetByServerId(videoExcept.ServerId));
            Assert.True(videoQuery.Count() > 0);
        }

        [Fact]
        public void Should_Be_Get_By_Server_Id_And_Return_A_Zero_Count()
        {
            var serverIdFake = Guid.NewGuid();
            var videoQuery = _items.AsQueryable().Where(VideoQueries.GetByServerId(serverIdFake));
            Assert.True(videoQuery.Count() == 0);
        }

        [Fact]
        public void Given_A_Date_Should_Be_Return_All_Date_With_Create_At_Before_Date()
        {
            var date = DateTime.Now.AddDays(5);
            var videoQuery = _items.AsQueryable().Where(VideoQueries.GetAllBeforeDate(date));
            Assert.True(videoQuery.Count() > 0);
        }

        [Fact]
        public void Given_A_Date_Should_Be_Return_No_Data()
        {
            var date = DateTime.Now.Subtract(TimeSpan.FromDays(5));
            var videoQuery = _items.AsQueryable().Where(VideoQueries.GetAllBeforeDate(date));
            Assert.True(videoQuery.Count() == 0);
        }

    }
}
