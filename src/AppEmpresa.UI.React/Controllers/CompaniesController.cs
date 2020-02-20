using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AppEmpresa.Domain.Contracts.Apps;
using AppEmpresa.Domain.Entities;
using AppEmpresa.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppEmpresa.UI.React.Controllers
{
    [ApiController]
    [Route("api/empresas")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CompaniesController : ControllerBase
    {
        private readonly CompanyAppContract _companyApp;
        public CompaniesController(CompanyAppContract companyApp)
        {
            _companyApp = companyApp;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Company company = new Company("10793548000190", "Company Name", State.SantaCatarina);

            //company = await _companyApp.Create(company);

            var teste = await _companyApp.Get(company.CNPJ);

            return Ok(company);
        }

        // GET: api/Companies/5
        [HttpGet("{cnpj}")]
        public string Get(string cnpj)
        {
            return "value";
        }

        // POST: api/Companies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
