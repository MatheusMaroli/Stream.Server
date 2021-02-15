using Microsoft.EntityFrameworkCore;
using Stream.Server.Domain.Entities;
using Stream.Server.Domain.Infra.Contexts;
using Stream.Server.Domain.Queries;
using Stream.Server.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Stream.Server.Domain.Infra.Repositories
{
    public class VideoRepository : BaseRepository, IVideoRepository
    {
        public VideoRepository(DataContext context) : base(context)
        {
        }

        public void Delete(Video video)
        {
         
            _dataContext.Videos.Remove(video);
            _dataContext.SaveChanges();
        
        }

        public IEnumerable<Video> GetByServerId(Guid serverId)
        {
            return _dataContext.Videos.AsTracking().Where(VideoQueries.GetByServerId(serverId));
        }

        public Video GetByServerIdAndVideoId(Guid serverId, Guid videoId)
        {
            return _dataContext.Videos.AsTracking().FirstOrDefault(VideoQueries.GetByServerIdAndVideoId(serverId, videoId));
        }

        public IEnumerable<Video> GetAllBeforeDate(DateTime date)
        {
            return _dataContext.Videos.AsTracking().Where(VideoQueries.GetAllBeforeDate(date)).ToList();
        }

        public void Save(Video video)
        {
            _dataContext.Videos.Add(video);
            _dataContext.SaveChanges();
        }

        public void SaveInFileSystem(Video video, byte[] binary)
        {
            var memoryStream = new MemoryStream(binary);
            var videoPath = MountVideoPath(video); 
            var file = new FileStream(videoPath, FileMode.Create, FileAccess.Write);
            memoryStream.WriteTo(file);
            file.Close();
            memoryStream.Close();
        }

        public void DeleteInFileSystem(Video video)
        {
            var videoPath = MountVideoPath(video);
            if (File.Exists(videoPath))
                File.Delete(videoPath);
        }

        private string MountVideoPath(Video video)
        {
            return Path.Combine(video.FileSystemPath, $"{video.FileName}");
        }

        public MemoryStream GetInFileSystem(Video video)
        {
            
            var videoPath = MountVideoPath(video);
            if (File.Exists(videoPath))
            {
                var memoryStream = new MemoryStream();
                var file = new FileStream(videoPath, FileMode.Open, FileAccess.Read);               
                file.CopyTo(memoryStream);
                file.Close();
                return memoryStream;

            }
            return null;
        }

   
    }
}
