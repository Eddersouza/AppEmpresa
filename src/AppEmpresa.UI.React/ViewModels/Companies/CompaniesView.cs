using System.Collections.Generic;

namespace AppEmpresa.UI.React.ViewModels.Companies
{
    public class CompaniesView
    {
        public CompaniesView(IList<CompanyView> companies)
        {
            Items = companies;
        }

        public IList<CompanyView> Items { get; set; }
    }
}