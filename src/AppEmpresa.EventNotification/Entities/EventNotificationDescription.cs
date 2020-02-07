using AppEmpresa.EventNotification.Base;
using AppEmpresa.EventNotification.Contracts;

namespace AppEmpresa.EventNotification.Entities
{
    public class EventNotificationDescription : EventNotificationDescriptionBase
    {
        public EventNotificationDescription(
             string message,
             EventNotificationLevelContract level,
             params string[] args)
             : base(message, args)
        {
            Level = level;
        }

        public EventNotificationLevelContract Level { get; }
    }
}