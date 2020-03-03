namespace AppEmpresa.UI.React.ViewModels.Params.States
{
    public class StateView
    {
        public StateView()
        {
        }

        public StateView(
            string code,
            string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}