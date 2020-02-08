﻿using AppEmpresa.App.Services;
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
            Assert.AreEqual(true, company.EventNotification.Errors.Select(x => x.ToString().Contains("CNPJ Inválido.")));
        }
    }
}