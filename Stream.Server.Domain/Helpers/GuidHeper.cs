using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Server.Domain.Helpers
{
    public static class GuidHeper
    {
        public static bool IsValid(this Guid _this)
        {
            var guid = new Guid();
            return !(_this == guid);
        }
    }
}
