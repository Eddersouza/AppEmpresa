using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AppEmpresa.Domain.Entities
{
    public class CompanyList : Entity
    {
        private IList<Company> _itens;

        public CompanyList()
        {
            _itens = new List<Company>();
        }

        public CompanyList(
            IList<Company> itens)
        {
            _itens = itens;
        }

        public IReadOnlyCollection<Company> Itens { get { return new ReadOnlyCollection<Company>(_itens); } }

        public void AddList(
                    IList<Company> itens)
        {
            _itens = itens;
        }
    }
}