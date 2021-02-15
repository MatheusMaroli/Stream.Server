using Stream.Server.Domain.Entities;
using Stream.Server.Domain.Repositories;
using Stream.Server.Domain.Test.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Stream.Server.Domain.Test.Repositories
{
    public class FakeVideoRepository : IVideoRepository
    {
        private DataContextMock _dataContext;

        public FakeVideoRepository(DataContextMock dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(Video video)
        {
            //
        }

        public void DeleteInFileSystem(Video video)
        {
           //
        }

        public IEnumerable<Video> GetByServerId(Guid serverId)
        {
            return _dataContext.Videos.AsQueryable().Where(Queries.VideoQueries.GetByServerId(serverId));
        }

        public Video GetByServerIdAndVideoId(Guid serverId, Guid videoId)
        {
            return _dataContext.Videos.AsQueryable().FirstOrDefault(Queries.VideoQueries.GetByServerIdAndVideoId(serverId, videoId));
        }

        public IEnumerable<Video> GetAllBeforeDate(DateTime date)
        {
            return _dataContext.Videos.ToList();
        }

        public MemoryStream GetInFileSystem(Video video)
        {
            var fakeMemoryStream = new MemoryStream();
            return fakeMemoryStream;
        }

        public void Save(Video video)
        {
            //
        }

        public void SaveInFileSystem(Video video, byte[] binary)
        {
            //
        }
    }
}
