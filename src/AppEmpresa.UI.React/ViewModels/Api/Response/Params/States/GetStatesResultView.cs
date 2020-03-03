using AppEmpresa.UI.React.ViewModels.Params.States;
using AppEmpresa.UI.React.ViewModels.Utils;
using System.Collections.Generic;

namespace AppEmpresa.UI.React.ViewModels.Api.Response.Params.States
{
    public class GetStatesResultView : NotificationView
    {
        public GetStatesResultView()
        {
            ErrorMessages = new List<string>();
            WarningMessages = new List<string>();
        }

        public GetStatesResultView(StatesView data) : this()
        {
            Data = data;
        }

        public StatesView Data { get; set; }
    }
}