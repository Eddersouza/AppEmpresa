using System.Collections.Generic;

namespace AppEmpresa.Domain.Entities
{
    public class CompanyList
    {
        private ICollection<Company> _itens;

        public CompanyList()
        {
            _itens = new List<Company>();
        }

        public CompanyList(
            ICollection<Company> itens)
        {
            _itens = itens;
        }

        public ICollection<Company> Itens { get { return _itens; } }
    }
}