using AppEmpresa.UI.React.ViewModels.Companies;
using AppEmpresa.UI.React.ViewModels.Utils;
using System.Linq;

namespace AppEmpresa.UI.React.ViewModels.Api.Response.Companies
{
    public class BaseCompanyResponseView : NotificationView
    {
        public BaseCompanyResponseView(
            CompanyView companyView,
            EventNotification.Entities.EventNotification eventNotification)
        {
            Data = companyView;
            ErrorMessages = eventNotification.Errors.Select(x => x.ToString()).ToList();
            WarningMessages = eventNotification.Warnings.Select(x => x.ToString()).ToList();
        }

        public CompanyView Data { get; set; }
    }
}