using Stream.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Stream.Server.Domain.Queries
{
    public static class VideoQueries
    {

        public static Expression<Func<Video, bool>> GetByServerIdAndVideoId(Guid serverId, Guid videoId)
        {
            return video => video.ServerId == serverId && video.Id == videoId;
        }

        public static Expression<Func<Video, bool>> GetByServerId(Guid id)
        {
            return video => video.ServerId == id;
        }

        public static Expression<Func<Video, bool>> GetAllBeforeDate(DateTime date)
        {
            return video => video.CreatedAt.Date < date.Date;
        }

    }
}
