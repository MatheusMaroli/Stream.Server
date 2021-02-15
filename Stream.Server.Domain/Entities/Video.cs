using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stream.Server.Domain.Entities
{
    public class Video :BaseEntity
    {
        [Required, MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public string FileSystemPath { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public int SizeInBytes { get; set; }
        [Required]
        public Guid ServerId { get; set; }
        [ForeignKey("ServerId")]
        public Server Server { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public Video() { }       

        public Video(Guid serverId, string description, string fileSystemPath, string fileName, int sizeInBytes)
        {
            ServerId = serverId;
            Description = description;
            FileSystemPath = fileSystemPath;
            CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(5));
            SizeInBytes = sizeInBytes;
            FileName = fileName;
        }


    }
}
