using AppEmpresa.EventNotification.Contracts;

namespace AppEmpresa.EventNotification.Entities.Levels
{
    public class EventNotificationInformation : EventNotificationLevelContract
    {
        public EventNotificationInformation(string description = "Information")
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