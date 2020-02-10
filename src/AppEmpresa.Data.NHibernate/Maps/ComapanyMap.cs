using AppEmpresa.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmpresa.Data.NHibernate.Maps
{
    public class ComapanyMap
        : ClassMap<Company>
    {
        public ComapanyMap()
        {
            Id(company => company.CNPJ);
            Map(company => company.CompanyName);
            Map(company => company.CreateDate);
            Map(company => company.StateCode);            
        }
    }
}
