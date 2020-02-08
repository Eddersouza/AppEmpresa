using AppEmpresa.EventNotification.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmpresa.Domain.Entities
{
    public class Entity : EventNotificationEntity
    {
        public Entity()
        {
            this.CreateDate = DateTime.Now;
        }

        public DateTime CreateDate { get; set; }

        public string CreatedByUserId { get; set; }
    }
}
