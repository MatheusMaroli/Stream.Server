using Stream.Server.Domain.Commands.Contracts;
using Stream.Server.Domain.CommandsBehaviors;


namespace Stream.Server.Domain.Commands.Server
{
    public class CreateServerCommand : NotificationValidatorContext, ICommand
    {

        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }


        public CreateServerCommand() { }
        public CreateServerCommand(string name, string ip, int port)
        {
            Name = name;
            Ip = ip;
            Port = port;
        }

   
        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddNotification("Nome do servidor não foi informado");
            if (string.IsNullOrEmpty(Ip))
                AddNotification("Ip do servidor não foi informado");
            if (Port == 0)
                AddNotification("Porta do servidor não foi informado");
        }
    }
}
