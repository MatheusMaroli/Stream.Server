using Stream.Server.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stream.Server.Api.Helpers
{
    public static class RecycleDataPresentation
    {
        public static RecyclePresentation RecycleToPresentationFormatter(Domain.Entities.Recycle recycle)
        {
            if (recycle == null)
            {
                return new RecyclePresentation() { Status = Domain.EnumType.RecyclerStatus.NotRunning };
            }
            return new RecyclePresentation() { Status = recycle.Status};
        }

        public static RecyclePresentation RecycleToPresentationFormatter(Domain.EnumType.RecyclerStatus status)
        {
            return new RecyclePresentation() { Status = status };
        }
    }
}
