﻿using AppEmpresa.App.Services;
using AppEmpresa.Domain.Contracts.Apps;
using AppEmpresa.Domain.Contracts.Repositories.Base;
using AppEmpresa.Domain.Entities;
using AppEmpresa.Domain.Enums;
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
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
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
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
            Company company = new Company("10793548000191", "Company Name", State.Acre);

            //Act
            company = await _companyApp.Create(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("CNPJ Inválido."));
        }

        [Test]
        public async void CreateCompany_CompanyName_Empty()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
            Company company = new Company("10793548000190", "", State.Acre);

            //Act
            company = await _companyApp.Create(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Nome da Empresa é obrigatório."));
        }

        [Test]
        public async void CreateCompany_StateEmpty()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
            Company company = new Company("10793548000190", "Company Name", null);

            //Act
            company = await _companyApp.Create(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Estado é obrigatório."));
        }

        [Test]
        public void DeleteCompany()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
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
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
            Company company = new Company("10793548000190", "", null);

            //Act
            company = _companyApp.Delete(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Empresa não encontrada."));
        }

        [Test]
        public void DeleteCompany_CNPJ_Required()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
            Company company = new Company("", "", null);

            //Act
            company = _companyApp.Delete(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("CNPJ da empresa é obrigatório."));
        }

        [Test]
        public void UpdateCompany()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
            Company company = new Company("10793548000190", "Company Name alt", State.Acre);

            //Act
            company = _companyApp.Update(company);

            //Assert
            Assert.AreEqual(true, company.IsValid());
        }

        [Test]
        public void UpdateCompany_NotUpdateCNPJ()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
            Company company = new Company("10793548000190", "Company Name alt", State.Acre);

            //Act
            company = _companyApp.Update(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("CNPJ Não pode ser alterado."));
        }

        [Test]
        public void UpdateCompany_NotFound()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
            Company company = new Company("10793548000190", "Company Name alt", State.Acre);

            //Act
            company = _companyApp.Update(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Empresa não encontrada."));
        }

        [Test]
        public void UpdateCompany_CompanyName_Empty()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
            Company company = new Company("10793548000190", "", State.Acre);

            //Act
            company = _companyApp.Update(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Nome da Empresa é obrigatório."));
        }

        [Test]
        public void UpdateCompany_StateEmpty()
        {
            //Arrange
            UnityOfWorkContract unityOfWork = new ResolveMock().Resolve();
            CompanyAppContract _companyApp = new CompanyApp(unityOfWork);
            Company company = new Company("10793548000190", "Company Name", null);

            //Act
            company = _companyApp.Update(company);

            //Assert
            Assert.AreEqual(true, company.EventNotification.Warnings.Select(x => x.ToString()).Contains("Estado é obrigatório."));
        }
    }
}