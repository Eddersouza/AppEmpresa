using AppEmpresa.Domain.Contracts.Repositories;
using AppEmpresa.Domain.Entities;
using AppEmpresa.Domain.Enums;
using Moq;
using System;
using System.Collections.Generic;

namespace AppEmpresa.Tests.MockRepositories
{
    public class MockCompanyRepository
    {
        private IList<Company> Companies = new List<Company>
        {
            new Company { CNPJ ="68522679000112", CompanyName = "Empresa Santa Catarina", CreateDate = DateTime.Now, State = State.SantaCatarina },
            new Company { CNPJ ="25119515000136", CompanyName = "Empresa Rio de Janeiro", CreateDate = DateTime.Now, State = State.RioDeJaneiro },
            new Company { CNPJ ="51464202000125", CompanyName = "Empresa São Paulo", CreateDate = DateTime.Now, State = State.SaoPaulo },
            new Company { CNPJ ="06219163000146", CompanyName = "Empresa Mato Grosso", CreateDate = DateTime.Now, State = State.MatoGrosso }
        };

        public CompanyRepositoryContract CreateCompanyRepository()
        {
            Mock<CompanyRepositoryContract> companyRepository = new Mock<CompanyRepositoryContract>();

            AddCreate(companyRepository);

            AddGet(companyRepository);

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
    }
}