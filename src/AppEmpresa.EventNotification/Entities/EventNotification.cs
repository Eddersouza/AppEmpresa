using AppEmpresa.EventNotification.Base;
using AppEmpresa.EventNotification.Entities.Levels;
using System.Collections.Generic;
using System.Linq;

namespace AppEmpresa.EventNotification.Entities
{
    public class EventNotification : EventNotificationBase
    {
        public IList<EventNotificationDescription> Errors =>
            List.Cast<EventNotificationDescription>()
            .Where(x => x.Level is EventNotificationError).ToList();

        public bool HasErrors =>
           List.Cast<EventNotificationDescription>()
           .Any(x => x.Level is EventNotificationError);

        public bool HasInformations =>
            List.Cast<EventNotificationDescription>()
            .Any(x => x.Level is EventNotificationInformation);

        public bool HasWarnings =>
            List.Cast<EventNotificationDescription>()
            .Any(x => x.Level is EventNotificationWarning);

        public IList<EventNotificationDescription> Informations =>
            List.Cast<EventNotificationDescription>()
            .Where(x => x.Level is EventNotificationInformation).ToList();

        public IList<EventNotificationDescription> Warnings =>
           List.Cast<EventNotificationDescription>()
           .Where(x => x.Level is EventNotificationWarning).ToList();
    }
}