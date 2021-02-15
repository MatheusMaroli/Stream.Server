using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Server.Domain.Test.Mocks
{
    public static class VideoMock
    {
        public static byte[] GetFakeValidVideo()
        {
            var bytes = "XXXX";
            byte[] _videoByte = Convert.FromBase64String(bytes);
            return _videoByte;
        }

        public static byte[] GetFakeInvalidVideo()
        {
            var bytes = string.Empty;
            byte[] _videoByte = Convert.FromBase64String(bytes);
            return _videoByte;
        }
    }
}
