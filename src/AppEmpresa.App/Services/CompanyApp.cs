using AppEmpresa.Domain.Contracts.Apps;
using AppEmpresa.Domain.Contracts.Repositories.Base;
using AppEmpresa.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AppEmpresa.App.Services
{
    public class CompanyApp : CompanyAppContract
    {
        private readonly UnityOfWorkContract _unityOfWork;

        public CompanyApp(UnityOfWorkContract unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<Company> Create(Company company)
        {
            try
            {
                await _unityOfWork.BeginTransaction();
                await _unityOfWork.Companies.Create(company);
                await _unityOfWork.Commit();

                return company;

            }
            catch (Exception)
            {
                await _unityOfWork.Rowback();

                return company;
            }

        }

        public Company Delete(Company company)
        {
            // throw new NotImplementedException();

            return company;
        }

        public async Task<CompanyList> Get()
        {
            CompanyList companyList = new CompanyList();
            return await _unityOfWork.Companies.Get(companyList);
        }

        public Company Update(Company company)
        {
            return company;

            //throw new NotImplementedException();
        }
    }
}