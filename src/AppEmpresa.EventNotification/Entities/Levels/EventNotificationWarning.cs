using AppEmpresa.EventNotification.Contracts;

namespace AppEmpresa.EventNotification.Entities.Levels
{
    public class EventNotificationWarning : EventNotificationLevelContract
    {
        public EventNotificationWarning(string description = "Warning")
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