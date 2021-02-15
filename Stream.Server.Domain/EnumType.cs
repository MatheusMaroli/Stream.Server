using System;
using System.Collections.Generic;
using System.Text;

namespace Stream.Server.Domain.EnumType
{
    public enum CommandResultStatus
    {
        Success, InvalidCommand, InvalidData, Exception
    }

    public enum RecyclerStatus
    {
        Running, NotRunning
    }
}
