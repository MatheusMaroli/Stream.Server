using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stream.Server.Api.Models
{
    public class VideoPresentation
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int SizeInBytes { get; set; }

        public VideoPresentation(Guid id, string description, int sizeInBytes)
        {
            Id = id;
            Description = description;
            SizeInBytes = sizeInBytes;
        }

     
    }
}
