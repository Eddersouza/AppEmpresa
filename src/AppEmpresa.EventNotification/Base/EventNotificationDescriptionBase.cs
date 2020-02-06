using AppEmpresa.EventNotification.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmpresa.EventNotification.Base
{
    public abstract class EventNotificationDescriptionBase : EventNotificationDescriptionBaseContract
    {
        protected EventNotificationDescriptionBase(string message, params string[] args)
        {
            Message = message;

            for (var i = 0; i < args.Length; i++)
            {
                Message = Message.Replace("{" + i + "}", args[i]);
            }
        }

        public string Message { get; }

        public override string ToString() => Message;
    }
}
