using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Server.Domain.Test.Mocks
{
    public class DataContextMock
    {
        public List<Entities.Server> Servers { get; set; }
        public List<Entities.Video> Videos { get; set; }

        public DataContextMock()
        {
            CreateServerFakeData();
            CreateVideoFakeData();
        }

        private void CreateServerFakeData()
        {
            Servers = new List<Entities.Server>() {
                new Entities.Server(Guid.NewGuid(), "Server 1", "10.1.1.1", 1),
                new Entities.Server(Guid.NewGuid(), "Server 2", "10.1.1.2", 2),
                new Entities.Server(Guid.NewGuid(), "Server 3", "10.1.1.3", 3),
                new Entities.Server(Guid.NewGuid(), "Server 4", "10.1.1.4", 4),
                new Entities.Server(Guid.NewGuid(), "Server 5", "10.1.1.5", 5)
            };
        }

        private void CreateVideoFakeData()
        {
            var serverIdFake = Guid.NewGuid();
            var bytes = "XXXX";
            byte[] _videoContent = Convert.FromBase64String(bytes);
            Videos = new List<Entities.Video>()
            {
                new Entities.Video(){ Id = Guid.NewGuid(), Description = "Video 1",  ServerId= serverIdFake, CreatedAt = DateTime.Now },
                new Entities.Video(){ Id = Guid.NewGuid(), Description = "Video 2",  ServerId= serverIdFake, CreatedAt = DateTime.Now },
                new Entities.Video(){ Id = Guid.NewGuid(), Description = "Video 3",  ServerId= serverIdFake, CreatedAt = DateTime.Now },
                new Entities.Video(){ Id = Guid.NewGuid(), Description = "Video 4",  ServerId= serverIdFake, CreatedAt = DateTime.Now },
                new Entities.Video(){ Id = Guid.NewGuid(), Description = "Video 5",  ServerId= serverIdFake, CreatedAt = DateTime.Now },
            };
        }
    }
}
