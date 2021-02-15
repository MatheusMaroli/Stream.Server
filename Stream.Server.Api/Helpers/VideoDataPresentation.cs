using Microsoft.AspNetCore.Mvc;
using Stream.Server.Api.Models;
using Stream.Server.Domain.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Stream.Server.Api.Helpers
{
    public class VideoDataPresentation
    {
        public static IEnumerable<VideoPresentation> VideoToPresentationFormatter(IEnumerable<Domain.Entities.Video> videos)
        {
            if (!videos.Any())
                return null;
            var list = new List<VideoPresentation>();
            foreach (var video in videos)
                list.Add(VideoToPresentationFormatter(video));
            return list;
        }

        public static VideoPresentation VideoToPresentationFormatter(Domain.Entities.Video video)
        {
            if (video == null)
                return null;            
            return new VideoPresentation(video.Id, video.Description, video.SizeInBytes);
        }
    }
}
