using AppEmpresa.Domain.Contracts.Apps;
using AppEmpresa.Domain.Entities;
using AppEmpresa.Domain.Enums;
using AppEmpresa.UI.React.ViewModels.Api.Request.Companies;
using AppEmpresa.UI.React.ViewModels.Api.Response.Companies;
using AppEmpresa.UI.React.ViewModels.Companies;
using AppEmpresa.Utils.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace AppEmpresa.UI.React.Controllers
{
    [ApiController]
    [Route("api/empresas")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CompaniesController : ControllerBase
    {
        private readonly CompanyAppContract _companyApp;

        private readonly IMapper _mapper;

        public CompaniesController(
            CompanyAppContract companyApp,
            IMapper mapper)
        {
            _companyApp = companyApp;
            _mapper = mapper;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            CompanyList companyList = await _companyApp.Get();

            GetCompaniesResponseView view = new GetCompaniesResponseView(
                new CompaniesView(_mapper.Map<IList<CompanyView>>(companyList.Itens)),
                companyList.EventNotification);

            if (companyList.EventNotification.HasWarnings)
                return StatusCode(400, view);

            if (companyList.EventNotification.HasErrors)
                return StatusCode(500, view);

            return Ok(view);
        }

        [HttpGet("{cnpj}")]
        public async Task<IActionResult> Get(string cnpj)
        {
            Company company = await _companyApp.Get(cnpj);

            GetCompanyResponseView view = new GetCompanyResponseView(
                _mapper.Map<CompanyView>(company),
                company.EventNotification);

            if (company.EventNotification.HasWarnings)
                return StatusCode(400, view);

            if (company.EventNotification.HasErrors)
                return StatusCode(500, view);

            return Ok(view);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNewCompanyView view)
        {
            Company company = new Company(view.CNPJ, view.CompanyName, view.StateCode.GetEnumByCode<State>(null));

            company = await _companyApp.Create(company);

            CreateCompanyResponseView viewResult = new CreateCompanyResponseView(
                _mapper.Map<CompanyView>(company),
                company.EventNotification);

            if (company.EventNotification.HasWarnings)
                return StatusCode(400, viewResult);

            if (company.EventNotification.HasErrors)
                return StatusCode(500, viewResult);

            return StatusCode(201, viewResult);
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UpdateNewCompanyView view)
        {
        }
    }
}