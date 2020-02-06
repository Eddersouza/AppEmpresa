namespace AppEmpresa.EventNotification.Contracts
{
    public interface EventNotificationDescriptionBaseContract
    {
        string Message { get; }

        string ToString();
    }
}