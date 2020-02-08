namespace AppEmpresa.EventNotification.Entities
{
    public class EventNotificationEntity
    {
        public EventNotification EventNotification { get; } = new EventNotification();

        public bool IsValid()
        {
            return !EventNotification.HasErrors
                && !EventNotification.HasWarnings
                && !EventNotification.HasInformations;
        }

        protected void TestCondition(
            bool condition,
            EventNotificationDescription description)
        {
            if (condition)
                EventNotification.Add(description);
        }
    }
}