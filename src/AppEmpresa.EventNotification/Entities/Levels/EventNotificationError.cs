using AppEmpresa.EventNotification.Contracts;

namespace AppEmpresa.EventNotification.Entities.Levels
{
    public class EventNotificationError : EventNotificationLevelContract
    {
        public EventNotificationError(string description = "Error")
        {
            Description = description;
        }

        public string Description { get; }

        public override string ToString()
        {
            return Description;
        }
    }
}