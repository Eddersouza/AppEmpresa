using AppEmpresa.Domain.Enums;
using AppEmpresa.EventNotification.Entities;
using AppEmpresa.EventNotification.Entities.Levels;
using AppEmpresa.Utils.Extensions;

namespace AppEmpresa.Domain.Entities
{
    public class Company : Entity
    {
        private static EventNotificationDescription InvalidCnpj =
            new EventNotificationDescription(
                "CNPJ Inválido.",
                new EventNotificationWarning());

        public Company()
        {
        }

        public Company(
            string cnpj,
            string companyName,
            State? state)
        {
            CNPJ = cnpj;
            CompanyName = companyName;
            State = state;
        }

        public string CNPJ { get; set; }
        public string CompanyName { get; set; }
        public State? State { get; set; }

        public void ValidateNewCompany()
        {
            TestCondition(!CNPJ.IsCnpj(), InvalidCnpj);
        }
    }
}