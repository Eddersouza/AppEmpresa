using AppEmpresa.Domain.Contracts.Apps;
using AppEmpresa.Domain.Contracts.Repositories.Base;
using AppEmpresa.Domain.Entities;
using AppEmpresa.EventNotification.Entities;
using AppEmpresa.EventNotification.Entities.Levels;
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
                company.ValidateNewCompany();

                if (!company.IsValid())
                    return company;

                await _unityOfWork.BeginTransaction();
                await _unityOfWork.Companies.Create(company);
                await _unityOfWork.Commit();

                return company;

            }
            catch
            {
                await _unityOfWork.Rowback();

                company.EventNotification.Add(new EventNotificationDescription(
                    "Ocorreu um erro ao Criar Nova Empresa.",
                    new EventNotificationError()));

                return company;
            }

        }

        public async Task<Company> Delete(Company company)
        {
            try
            {
                await _unityOfWork.BeginTransaction();

                Company companyToDelete = await _unityOfWork.Companies.Get(company.CNPJ);

                if (companyToDelete == null)
                {
                    company.EventNotification.Add(new EventNotificationDescription(
                        "Empresa não encontrada.",
                        new EventNotificationWarning()));

                }
                else
                {
                    await _unityOfWork.Companies.Delete(companyToDelete);
                    await _unityOfWork.Commit();
                }

                return company;
            }
            catch
            {
                await _unityOfWork.Rowback();

                company.EventNotification.Add(new EventNotificationDescription(
                    "Ocorreu um erro ao Excluir Empresa.",
                    new EventNotificationError()));

                return company;
            }
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