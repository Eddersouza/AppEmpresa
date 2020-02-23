using AppEmpresa.Domain.Enums;

namespace AppEmpresa.UI.React.ViewModels.Companies
{
    public class CompanyView
    {
        public string CNPJ { get; set; }
        public string CompanyName { get; set; }
        public State? State { get; set; }
        public string StateCode { get; set; }
    }
}