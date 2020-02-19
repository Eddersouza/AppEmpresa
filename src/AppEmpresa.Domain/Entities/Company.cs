using AppEmpresa.Domain.Enums;
using AppEmpresa.EventNotification.Entities;
using AppEmpresa.EventNotification.Entities.Levels;
using AppEmpresa.Utils.Extensions;

namespace AppEmpresa.Domain.Entities
{
    public class Company : Entity
    {
        private static EventNotificationDescription CnpjInvalid =
            new EventNotificationDescription(
                "CNPJ Inválido.",
                new EventNotificationWarning());

        private static EventNotificationDescription CnpjRequired =
            new EventNotificationDescription(
                "CNPJ da Empresa é obrigatório.",
                new EventNotificationWarning());

        private static EventNotificationDescription NameEmpty =
          new EventNotificationDescription(
              "Nome da Empresa é obrigatório.",
              new EventNotificationWarning());

        private static EventNotificationDescription StateEmpty =
            new EventNotificationDescription(
                "Estado é obrigatório.",
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

        public virtual string CNPJ { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual State? State { get; set; }
        public virtual string StateCode
        {
            get { return State.GetCode(); }
            set { State = value.GetEnumByCode<State>(Enums.State.EscolhaUmEstado); }
        }

        public override object[] ChavePrimaria
        {
            get { return new object[] { CNPJ }; }
        }

        public virtual void ValidateDeleteCompany()
        {
            TestCondition(CNPJ.IsNullOrEmpty(), CnpjRequired);
        }

        public virtual void ValidateNewOrUpdateCompany()
        {
            TestCondition(CNPJ.IsNullOrEmpty(), CnpjRequired);
            TestCondition(!CNPJ.IsCnpj(), CnpjInvalid);
            TestCondition(CompanyName.IsNullOrEmpty(), NameEmpty);
            TestCondition(!State.HasValue || State.Value.Equals(Enums.State.EscolhaUmEstado), StateEmpty);
        }
    }
}