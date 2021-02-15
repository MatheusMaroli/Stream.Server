using Stream.Server.Domain.Commands.Contracts;
using Stream.Server.Domain.CommandsBehaviors;

namespace Stream.Server.Domain.Commands.Recycle
{
    public class RecycleVideoForMoreThenDaysCommand : NotificationValidatorContext, ICommand
    {
        public int Days { get;set; }

        public RecycleVideoForMoreThenDaysCommand() { }
        public RecycleVideoForMoreThenDaysCommand(int days)
        {
            Days = days;
        }

        public override void Validate()
        {
            if (Days < 0)
                AddNotification("Número de dias deve ser maior que zero");
        }
    }
}
