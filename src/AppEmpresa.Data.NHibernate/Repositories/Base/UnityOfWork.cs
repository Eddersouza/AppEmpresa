using AppEmpresa.Domain.Contracts.Repositories;
using AppEmpresa.Domain.Contracts.Repositories.Base;
using NHibernate;

namespace AppEmpresa.Data.NHibernate.Repositories.Base
{
    public class UnityOfWork : UnityOfWorkContract
    {
        private readonly CompanyRepositoryContract _companyRepository;

        protected ISession _session = null;
        protected ITransaction _transaction = null;

        public CompanyRepositoryContract Companies => _companyRepository;

        public UnityOfWork(
            CompanyRepositoryContract companyRepository,
            ISession session)
        {
            _companyRepository = companyRepository;
            _session = session;
        }

        public void BeginTransaction()
        {
            _session.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();

            CloseTransaction();
        }

        public void Rowback()
        {
            _transaction.Rollback();

            CloseTransaction();
            CloseSession();
        }

        private void CloseTransaction()
        {
            _transaction.Dispose();
            _transaction = null;
        }

        private void CloseSession()
        {
            _session.Close();
            _session.Dispose();
            _session = null;
        }
    }
}