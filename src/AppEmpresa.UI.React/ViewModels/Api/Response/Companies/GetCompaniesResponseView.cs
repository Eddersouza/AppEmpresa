using AppEmpresa.UI.React.ViewModels.Companies;
using AppEmpresa.UI.React.ViewModels.Utils;
using System.Linq;

namespace AppEmpresa.UI.React.ViewModels.Api.Response.Companies
{
    public class GetCompaniesResponseView : NotificationView
    {
        public GetCompaniesResponseView(
            CompaniesView companyView,
            EventNotification.Entities.EventNotification eventNotification)
        {
            Data = companyView;
            ErrorMessages = eventNotification.Errors.Select(x => x.ToString()).ToList();
            WarningMessages = eventNotification.Warnings.Select(x => x.ToString()).ToList();
        }

        public CompaniesView Data { get; set; }
    }
}