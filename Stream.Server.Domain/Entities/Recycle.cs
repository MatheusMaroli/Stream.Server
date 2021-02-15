using Stream.Server.Domain.EnumType;
using System;

namespace Stream.Server.Domain.Entities
{
    public class Recycle : BaseEntity
    {
        public RecyclerStatus Status { get; set; }
        public DateTime LastRunnedAt { get; set; }

        public Recycle() { }
        public Recycle(RecyclerStatus status, DateTime lastRunnedAt)
        {
            Status = status;
            LastRunnedAt = lastRunnedAt;
        }

        public void SetRunning(DateTime lastRunnedAt)
        {
            Status = RecyclerStatus.Running;
            LastRunnedAt = lastRunnedAt;
        }

        public void StopRunning()
        {
            Status = RecyclerStatus.NotRunning;
        }
    }
}
