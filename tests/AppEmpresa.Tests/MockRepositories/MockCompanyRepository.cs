﻿using AppEmpresa.Domain.Contracts.Repositories;
using AppEmpresa.Domain.Entities;
using AppEmpresa.Domain.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppEmpresa.Tests.MockRepositories
{
    public class MockCompanyRepository
    {
        private IList<Company> Companies = new List<Company>();

        public CompanyRepositoryContract CreateCompanyRepository()
        {
            Companies = new List<Company>
            {
                new Company { CNPJ ="68522679000112", CompanyName = "Empresa Santa Catarina", CreateDate = DateTime.Now, State = State.SantaCatarina },
                new Company { CNPJ ="25119515000136", CompanyName = "Empresa Rio de Janeiro", CreateDate = DateTime.Now, State = State.RioDeJaneiro },
                new Company { CNPJ ="51464202000125", CompanyName = "Empresa São Paulo", CreateDate = DateTime.Now, State = State.SaoPaulo },
                new Company { CNPJ ="06219163000146", CompanyName = "Empresa Mato Grosso", CreateDate = DateTime.Now, State = State.MatoGrosso }
            };

            Mock<CompanyRepositoryContract> companyRepository = new Mock<CompanyRepositoryContract>();

            AddCreate(companyRepository);

            AddGet(companyRepository);

            AddGetCompany(companyRepository);

            AddDelete(companyRepository);

            AddUpdate(companyRepository);

            return companyRepository.Object;
        }

        private void AddCreate(
            Mock<CompanyRepositoryContract> companyRepository)
        {
            companyRepository.Setup(cr => cr.Create(It.IsAny<Company>()))
                .ReturnsAsync((Company company) =>
                {
                    Companies.Add(company);

                    return company;
                });
        }

        private void AddDelete(Mock<CompanyRepositoryContract> companyRepository)
        {
            companyRepository.Setup(cr => cr.Delete(It.IsAny<Company>()))
                .ReturnsAsync((Company company) =>
                {
                    var companyToDelete = Companies.FirstOrDefault(x => x.CNPJ == company.CNPJ);

                    Companies.Remove(companyToDelete);

                    return company;
                });
        }

        private void AddGet(
            Mock<CompanyRepositoryContract> companyRepository)
        {
            companyRepository.Setup(cr => cr.Get(It.IsAny<CompanyList>()))
                .ReturnsAsync((CompanyList companyList) =>
            {
                companyList.AddList(Companies);

                return companyList;
            });
        }

        private void AddGetCompany(
            Mock<CompanyRepositoryContract> companyRepository)
        {
            companyRepository.Setup(cr => cr.Get(It.IsAny<object[]>()))
                .ReturnsAsync((object[] primaryKeys) =>
                {
                    return Companies.FirstOrDefault(x => x.CNPJ == primaryKeys[0].ToString());
                });
        }

        private void AddUpdate(
            Mock<CompanyRepositoryContract> companyRepository)
        {
            companyRepository.Setup(cr => cr.Update(It.IsAny<Company>()))
              .ReturnsAsync((Company company) =>
              {
                  var companyToUpdate = Companies.FirstOrDefault(x => x.CNPJ == company.CNPJ);

                  if (companyToUpdate == null)
                      return company;

                  companyToUpdate.CompanyName = company.CompanyName;
                  companyToUpdate.State = company.State;

                  return companyToUpdate;
              });
        }
    }
}