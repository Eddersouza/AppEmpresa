using AppEmpresa.Domain.Enums;

namespace AppEmpresa.Domain.Entities
{
    public class Company : Entity
    {
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
    }
}