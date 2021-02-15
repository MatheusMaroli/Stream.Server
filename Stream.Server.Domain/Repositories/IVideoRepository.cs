using Stream.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Stream.Server.Domain.Repositories
{
    public interface IVideoRepository
    {
        void Save(Video video);
        void Delete(Video video);
        MemoryStream GetInFileSystem(Video video);
        void SaveInFileSystem(Video video, byte[] binary);
        void DeleteInFileSystem(Video video);
        IEnumerable<Video> GetByServerId(Guid serverId);
        IEnumerable<Video> GetAllBeforeDate(DateTime date);
        Video GetByServerIdAndVideoId(Guid serverId, Guid videoId);

    }
}
