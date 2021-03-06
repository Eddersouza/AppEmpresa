﻿using AppEmpresa.Data.NHibernate.Repositories.Base;
using AppEmpresa.Domain.Contracts.Repositories;
using AppEmpresa.Domain.Entities;
using Dapper;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEmpresa.Data.NHibernate.Repositories
{
    public class CompanyRepository
        : BaseRepository<Company>,
        CompanyRepositoryContract
    {
        private string sqlQueryBase =
            @"SELECT
                CNPJ
                ,   CompanyName
                ,   StateCode
                ,   CreateDate
            FROM
                Core.Companies";

        public CompanyRepository(ISession session) : base(session)
        {
        }

        public async Task<Company> Get(object[] id)
        {
            StringBuilder query = new StringBuilder();
            Dictionary<string, object> queryParams = new Dictionary<string, object>();
            List<string> whereParams = new List<string>();

            queryParams.Add("@CNPJ", id[0].ToString());

            query.Append(sqlQueryBase);

            whereParams.Add("CNPJ = @CNPJ");

            if (whereParams.Any())
                query.AppendFormat(" WHERE {0}", string.Join(" AND ", whereParams));

            var connection = _session.Connection;
            return await connection.QueryFirstOrDefaultAsync<Company>(query.ToString(), queryParams);
        }

        public async Task<CompanyList> Get(CompanyList companyList)
        {
            StringBuilder query = new StringBuilder();
            Dictionary<string, object> queryParams = new Dictionary<string, object>();
            List<string> whereParams = new List<string>();

            query.Append(sqlQueryBase);

            var connection = _session.Connection;
            var list = await connection.QueryAsync<Company>(query.ToString());

            companyList.AddList(list.AsList());

            return companyList;
        }
    }
}