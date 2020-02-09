﻿using AppEmpresa.Domain.Entities;
using System.Threading.Tasks;

namespace AppEmpresa.Domain.Contracts.Apps
{
    public interface CompanyAppContract
    {
        Task<Company> Create(Company company);

        Task<Company> Delete(Company company);

        Task<CompanyList> Get();

        Company Update(Company company);
    }
}