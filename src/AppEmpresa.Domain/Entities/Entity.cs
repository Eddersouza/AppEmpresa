using AppEmpresa.EventNotification.Entities;
using System;

namespace AppEmpresa.Domain.Entities
{
    public class Entity : EventNotificationEntity
    {
        public Entity()
        {
            this.CreateDate = DateTime.Now;
        }

        public DateTime CreateDate { get; set; }
    }
}