using Stream.Server.Domain.Entities;
using Stream.Server.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Stream.Server.Domain.Test.Repositories
{
    public class FakeExceptionVideoRepository : IVideoRepository
    {
        public void Delete(Video video)
        {
            throw new Exception("Force Exception");
        }

        public void DeleteInFileSystem(Video video)
        {
            throw new Exception("Force Exception");
        }

        public IEnumerable<Video> GetAllBeforeDate(DateTime date)
        {
            throw new Exception("Force Exception");
        }

        public IEnumerable<Video> GetByServerId(Guid serverId)
        {
            throw new Exception("Force Exception");
        }

        public Video GetByServerIdAndVideoId(Guid serverId, Guid videoId)
        {
            throw new Exception("Force Exception");
        }

        public MemoryStream GetInFileSystem(Video video)
        {
            throw new NotImplementedException();
        }

        public void Save(Video video)
        {
            throw new Exception("Force Exception");
        }

        public void SaveInFileSystem(Video video, byte[] binary)
        {
            throw new Exception("Force Exception");
        }
    }
}
