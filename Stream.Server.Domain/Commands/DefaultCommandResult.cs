using Stream.Server.Domain.Commands.Contracts;
using Stream.Server.Domain.EnumType;

namespace Stream.Server.Domain.Commands
{
    public class DefaultCommandResult : ICommandResult
    {
        public CommandResultStatus Status {get;set;}
        public string Message { get; set; }
        public object Data { get; set; }

        public bool IsInvalidCommand => Status == CommandResultStatus.InvalidCommand;
        public bool IsSuccess => Status == CommandResultStatus.Success;
        public bool IsException => Status == CommandResultStatus.Exception;
        public bool IsInvalidData => Status == CommandResultStatus.InvalidData;

        public DefaultCommandResult()
        {
            Status = CommandResultStatus.Success;
            SetDefaultMessage();
            Data = null;
        }

        public DefaultCommandResult(CommandResultStatus status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public DefaultCommandResult(CommandResultStatus status, object data)
        {
            Status = status;
            SetDefaultMessage();
            Data = data;
        }

        public DefaultCommandResult(CommandResultStatus status)
        {
            Status = status;
            SetDefaultMessage();
            Data = null;
        }

        public DefaultCommandResult(object data)
        {
            Status = CommandResultStatus.Success;
            Message = "Success Operation";
            Data = data;
        }

        private void SetDefaultMessage()
        {
            if (IsInvalidCommand)
                Message = "Invalid Command";
            else if (IsException)
                Message = "Is a Exception";
            else if (IsInvalidData)
                Message = "Is a Invalid Data";
            else
                Message = "Success Operation";
        }
    }
}
