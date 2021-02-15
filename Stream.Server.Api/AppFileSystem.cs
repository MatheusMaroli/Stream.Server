using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stream.Server.Api
{
    public static class AppFileSystem
    {
        public static string VideosPath { get; private set; }
        public static void SetVideoPath(string path)
        {
            VideosPath = System.IO.Path.Combine(path, "mp4");
            if (!System.IO.Directory.Exists(VideosPath)) 
                System.IO.Directory.CreateDirectory(VideosPath);
        }
    }
}
