using AppEmpresa.Domain.Enums;
using AppEmpresa.Utils.Extensions;

namespace AppEmpresa.UI.React.ViewModels.Companies
{
    public class CompanyView
    {
        public string CNPJ { get; set; }
        public string CompanyName { get; set; }
        public State? State { get; set; }
        public string StateCode { get; set; }

        public string StateDescription
        {
            get
            {
                if (!State.HasValue)
                    return string.Empty;

                return State.GetDescription();
            }
        }
    }
}