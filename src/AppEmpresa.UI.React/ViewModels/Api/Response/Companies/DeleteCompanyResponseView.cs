using AppEmpresa.UI.React.ViewModels.Companies;

namespace AppEmpresa.UI.React.ViewModels.Api.Response.Companies
{
    public class DeleteCompanyResponseView : BaseCompanyResponseView
    {
        public DeleteCompanyResponseView(
            CompanyView companyView,
            EventNotification.Entities.EventNotification eventNotification) : base(companyView, eventNotification)
        {
        }
    }
}