using AppEmpresa.App.Services;
using AppEmpresa.Domain.Contracts.Apps;
using AppEmpresa.Domain.Contracts.Repositories.Base;
using AppEmpresa.Domain.Contracts.Services;
using AppEmpresa.Domain.Entities;
using AppEmpresa.Domain.Enums;
using AppEmpresa.Domain.Services;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace AppEmpresa.Tests
{
    public class CompanyTests
    {
        [Test]
        public async Task CreateCompany()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("10793548000190", "Company Name", State.Acre);

            //Act
            company = await _companyApp.Create(company);
            CompanyList itens = await _companyApp.Get();
            //Assert
            Assert.AreEqual(true, company.IsValid());
            Assert.AreEqual(5, itens.Itens.Count);
        }

        [Test]
        public async Task CreateCompany_CNPJ_Wrong()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("10793548000191", "Company Name", State.Acre);

            //Act
            company = await _companyApp.Create(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("CNPJ Inválido."));
        }

        [Test]
        public async Task CreateCompany_CompanyName_Empty()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("10793548000190", "", State.Acre);

            //Act
            company = await _companyApp.Create(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Nome da Empresa é obrigatório."));
        }

        [Test]
        public async Task CreateCompany_StateEmpty()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("10793548000190", "Company Name", null);

            //Act
            company = await _companyApp.Create(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Estado é obrigatório."));
        }

        [Test]
        public async Task CreateCompany_AlreadExists()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("68522679000112", "Company Name", null);

            //Act
            company = await _companyApp.Create(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Empresa já Cadastrada."));
        }

        [Test]
        public async Task DeleteCompany()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("68522679000112", "", null);

            //Act
            company = await _companyApp.Delete(company);
            CompanyList itens = await _companyApp.Get();

            //Assert
            Assert.AreEqual(3, itens.Itens.Count);
        }

        [Test]
        public async Task DeleteCompany_CNPJ_Required()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("", "", null);

            //Act
            company = await _companyApp.Delete(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("CNPJ da Empresa é obrigatório."));
        }

        [Test]
        public async Task DeleteCompany_NotFound()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("10793548000190", "", null);

            //Act
            company = await _companyApp.Delete(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Empresa não encontrada."));
        }

        [Test]
        public async Task UpdateCompany()
        {
            string newName = "Company Name alt";
            State newState = State.SantaCatarina;
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("68522679000112", newName, newState);

            //Act
            company = await _companyApp.Update(company);
            Company companyUpdated = await _companyApp.Get(company.CNPJ);

            //Assert
            Assert.AreEqual(true, companyUpdated.CompanyName == newName && companyUpdated.State == newState);
        }

        [Test]
        public async Task UpdateCompany_CompanyName_Empty()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("10793548000190", "", State.Acre);

            //Act
            company = await _companyApp.Update(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Nome da Empresa é obrigatório."));
        }

        [Test]
        public async Task UpdateCompany_NotFound()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("10793548000190", "Company Name alt", State.Acre);

            //Act
            company = await _companyApp.Update(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Empresa não encontrada."));
        }

        [Test]
        public async Task UpdateCompany_StateEmpty()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyServiceContract companyService = new CompanyService(unityOfWork);
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork, companyService);

            Company company = new Company("10793548000190", "Company Name", null);

            //Act
            company = await _companyApp.Update(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Estado é obrigatório."));
        }
    }
}