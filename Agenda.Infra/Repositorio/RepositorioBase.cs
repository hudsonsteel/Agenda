using Agenda.Dominio.Interfaces.Uow;
using System;
using System.Data;

namespace Agenda.Infra.Repositorio
{
    public abstract class RepositorioBase : IDisposable
    {
        protected IDbConnection connection { get { return transaction.Connection; } }
        protected IDbTransaction transaction { get; private set; }
        public RepositorioBase(IUnityOfWork iunityOfWork)
        {
            transaction = iunityOfWork._transaction;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            connection?.Dispose();
        }
    }
}
