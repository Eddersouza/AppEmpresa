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
                company.ValidateNewOrUpdateCompany();

                if (!company.IsValid())
                    return company;

                _unityOfWork.BeginTransaction();
                await _unityOfWork.Companies.Create(company);
                _unityOfWork.Commit();

                return company;
            }
            catch
            {
                _unityOfWork.Rowback();

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
                company.ValidateDeleteCompany();

                if (!company.IsValid())
                    return company;

                _unityOfWork.BeginTransaction();

                Company companyToDelete = await _unityOfWork.Companies.Get(company.PrimaryKeys);

                if (companyToDelete == null)
                    company.EventNotification.Add(new EventNotificationDescription(
                        "Empresa não encontrada.",
                        new EventNotificationWarning()));
                else
                    await _unityOfWork.Companies.Delete(companyToDelete);

                _unityOfWork.Commit();

                return company;
            }
            catch (Exception ex)
            {
                _unityOfWork.Rowback();

                company.EventNotification.Add(new EventNotificationDescription(
                    "Ocorreu um erro ao Excluir Empresa.",
                    new EventNotificationError()));

                return company;
            }
        }

        public async Task<CompanyList> Get()
        {
            CompanyList companyList = new CompanyList();

            try
            {
                companyList = await _unityOfWork.Companies.Get(companyList);

                return companyList;
            }
            catch
            {
                _unityOfWork.Rowback();

                companyList.EventNotification.Add(new EventNotificationDescription(
                    "Ocorreu um erro ao Buscar Empresa.",
                    new EventNotificationError()));

                return companyList;
            }
        }

        public async Task<Company> Get(string cnpj)
        {
            Company company = new Company(cnpj, string.Empty, null);

            try
            {
                company = await _unityOfWork.Companies.Get(company.PrimaryKeys);
                return company;
            }
            catch
            {
                _unityOfWork.Rowback();

                company.EventNotification.Add(new EventNotificationDescription(
                    "Ocorreu um erro ao Buscar Empresa.",
                    new EventNotificationError()));

                return company;
            }
        }

        public async Task<Company> Update(Company company)
        {
            try
            {
                company.ValidateNewOrUpdateCompany();

                Company companyToUpdate = await _unityOfWork.Companies.Get(company.PrimaryKeys);

                if (companyToUpdate == null)
                    company.EventNotification.Add(new EventNotificationDescription(
                        "Empresa não encontrada.",
                        new EventNotificationWarning()));

                if (!company.IsValid())
                    return company;

                _unityOfWork.BeginTransaction();
                await _unityOfWork.Companies.Update(company);

                company = await _unityOfWork.Companies.Get(company.PrimaryKeys);
                _unityOfWork.Commit();

                return company;
            }
            catch
            {
                _unityOfWork.Rowback();

                company.EventNotification.Add(new EventNotificationDescription(
                    "Ocorreu um erro ao Alterar Empresa.",
                    new EventNotificationError()));

                return company;
            }
        }
    }
}