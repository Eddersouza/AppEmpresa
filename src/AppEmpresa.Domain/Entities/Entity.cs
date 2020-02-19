using AppEmpresa.EventNotification.Entities;
using System;

namespace AppEmpresa.Domain.Entities
{
    public abstract class Entity : EventNotificationEntity
    {
        public Entity()
        {
            this.CreateDate = DateTime.Now;
        }

        public virtual DateTime CreateDate { get; set; }

        public abstract object[] PrimaryKeys { get; }
    }
}