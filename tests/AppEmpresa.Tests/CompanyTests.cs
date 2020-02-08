using AppEmpresa.App.Services;
using AppEmpresa.Domain.Contracts.Apps;
using AppEmpresa.Domain.Entities;
using AppEmpresa.Domain.Enums;
using NUnit.Framework;
using System.Linq;

namespace AppEmpresa.Tests
{
    public class CompanyTests
    {
        [Test]
        public void CreateCompany()
        {
            //Arrange
            CompanyAppContract _companyApp = new CompanyApp();
            Company company = new Company("10793548000190", "Company Name", State.Acre);

            //Act
            company = _companyApp.Create(company);

            //Assert
            Assert.AreEqual(true, company.IsValid());
        }


        [Test]
        public void CreateCompany_CNPJ_Wrong()
        {
            //Arrange
            CompanyAppContract _companyApp = new CompanyApp();
            Company company = new Company("10793548000190", "Company Name", State.Acre);

            //Act
            company = _companyApp.Create(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString().Contains("CNPJ Inválido.")));
        }


        [Test]
        public void CreateCompany_CompanyName_Empty()
        {
            //Arrange
            CompanyAppContract _companyApp = new CompanyApp();
            Company company = new Company("10793548000190", "", State.Acre);

            //Act
            company = _companyApp.Create(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString().Contains("Nome da Empresa é obrigatório.")));
        }

        [Test]
        public void CreateCompany_StateEmpty()
        {
            //Arrange
            CompanyAppContract _companyApp = new CompanyApp();
            Company company = new Company("10793548000190", "Company Name", null);

            //Act
            company = _companyApp.Create(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString().Contains("Estado é obrigatório.")));
        }

        [Test]
        public void DeleteCompany()
        {
            //Arrange
            CompanyAppContract _companyApp = new CompanyApp();
            Company company = new Company("10793548000190", "", null);

            //Act
            company = _companyApp.Delete(company);

            //Assert
            Assert.AreEqual(true, company.IsValid());
        }

        [Test]
        public void DeleteCompany_NotFound()
        {
            //Arrange
            CompanyAppContract _companyApp = new CompanyApp();
            Company company = new Company("10793548000190", "", null);

            //Act
            company = _companyApp.Delete(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString().Contains("Empresa não encontrada.")));
        }
    }
}