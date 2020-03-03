using System.Collections.Generic;

namespace AppEmpresa.UI.React.ViewModels.Params.States
{
    public class StatesView
    {
        public StatesView(IList<StateView> companies)
        {
            Items = companies;
        }

        public IList<StateView> Items { get; set; }
    }
}