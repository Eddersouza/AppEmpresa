using AppEmpresa.EventNotification.Base;
using System.Collections.Generic;

namespace AppEmpresa.EventNotification.Contracts
{
    public interface EventNotificationBaseContract
    {
        bool HasNotifications { get; }

        IList<object> List { get; }

        void Add(EventNotificationDescriptionBase eventNotification);

        void Add(IList<object> eventNotification);

        bool Includes(EventNotificationDescriptionBase eventNotification);
    }
}