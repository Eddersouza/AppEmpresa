using AppEmpresa.EventNotification.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AppEmpresa.EventNotification.Base
{
    public abstract class EventNotificationBase : EventNotificationBaseContract
    {
        public bool HasNotifications => List.Any();

        public IList<object> List { get; } = new List<object>();

        public void Add(EventNotificationDescriptionBase eventNotification)
        {
            List.Add(eventNotification);
        }

        public void Add(IList<object> eventNotification)
        {
            foreach (var item in eventNotification)
            {
                List.Add(item);
            }
        }

        public bool Includes(EventNotificationDescriptionBase eventNotification)
        {
            return List.Contains(eventNotification);
        }
    }
}