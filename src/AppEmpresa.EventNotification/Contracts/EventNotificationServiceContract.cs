using System.Collections;

namespace AppEmpresa.EventNotification.Contracts
{
    public interface EventNotificationServiceContract
    {
        bool HasErrors { get; }

        bool HasInformations { get; }

        bool HasNotifications { get; }

        bool HasWarnings { get; }

        IEnumerable Errors();

        IEnumerable Informations();

        IEnumerable Warnings();
    }
}