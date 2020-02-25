using AppEmpresa.UI.React.ViewModels.Companies;

namespace AppEmpresa.UI.React.ViewModels.Api.Response.Companies
{
    public class UpdateCompanyResponseView : BaseCompanyResponseView
    {
        public UpdateCompanyResponseView(
            CompanyView companyView,
            EventNotification.Entities.EventNotification eventNotification) : base(companyView, eventNotification)
        {
        }
    }
}