﻿using AppEmpresa.UI.React.ViewModels.Companies;

namespace AppEmpresa.UI.React.ViewModels.Api.Response.Companies
{
    public class CreateCompanyResponseView : BaseCompanyResponseView
    {
        public CreateCompanyResponseView(
            CompanyView companyView,
            EventNotification.Entities.EventNotification eventNotification) : base(companyView, eventNotification)
        {
        }
    }
}