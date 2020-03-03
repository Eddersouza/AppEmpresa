using AppEmpresa.Domain.Enums;
using AppEmpresa.UI.React.ViewModels.Api.Response.Params.States;
using AppEmpresa.UI.React.ViewModels.Params.States;
using AppEmpresa.Utils.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;

namespace AppEmpresa.UI.React.Controllers
{
    [ApiController]
    [Route("api/parametros")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ParamsController : Controller
    {
        [HttpGet("estados")]
        public IActionResult States()
        {
            IEnumerable<State> statesEnum = (IEnumerable<State>)Enum.GetValues(typeof(State));
            IEnumerable<StateView> states =
                statesEnum
                .Where(x => !x.Equals(State.EscolhaUmEstado))
                .Select(x => new StateView(x.GetCode(), x.GetDescription()));

            GetStatesResultView view = new GetStatesResultView(new StatesView(states.ToList()));

            return Ok(view);
        }
    }
}