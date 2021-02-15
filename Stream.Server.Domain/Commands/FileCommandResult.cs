using Stream.Server.Domain.EnumType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Stream.Server.Domain.Commands
{
    public class FileCommandResult : DefaultCommandResult, Contracts.ICommandResult
    {
     
        public MemoryStream File { get; private set; } = null;
        public FileCommandResult() : base()
        { 

        }


        public FileCommandResult(object data, MemoryStream file) : 
            base(CommandResultStatus.Success, data )
        {
            File = file;
        }

        public FileCommandResult(MemoryStream file) : base(CommandResultStatus.Success)
        {
            File = file;
        }

        public FileCommandResult(CommandResultStatus status, object data) : base(status, data)
        {
            File = null;
        }

        public FileCommandResult(CommandResultStatus status) : base(status)
        {
            File = null;
        }
    }
}
