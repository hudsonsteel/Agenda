using Agenda.Dominio.Interfaces.Repositorio;
using System;
using System.Data;

namespace Agenda.Dominio.Interfaces.Uow
{
    public interface IUnityOfWork : IDisposable
    {
        IContatoRepositorio IContatoRepositorio { get; }
        IStoredEventRepositorio IStoredEventRepositorio { get; }
        IDbTransaction _transaction { get; }
        bool Commit();
    }
}
