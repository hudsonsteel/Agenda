using Agenda.Dominio.Interfaces.Repositorio;
using Agenda.Dominio.Interfaces.Uow;
using Agenda.Infra.Interfaces.Servico;
using Agenda.Infra.Repositorio;
using Agenda.Infra.Repositorio.EventSourcing;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Agenda.Infra.Uow
{
    public class UnitOfWork : IUnityOfWork
    {
        private bool _disposed;

        private IDbConnection _connection;
        public IDbTransaction _transaction { get; private set; }
        public IDbTransaction isqlServerVerifyServico { get; private set; }

        private readonly string nomeBanco;
        private readonly string connectionString;

        private UnitOfWork()
        {
            nomeBanco = $@"AgendaTelefonica";
            //Conection String SQL SERVER 2012
            //(localdb)\MSSQLLocalDB
            //DESKTOP-MVG3E2S\SQLEXPRESS
            connectionString = $@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog={nomeBanco}; Integrated Security=SSPI;";
        }
        public UnitOfWork(ISqlServerVerifyServico isqlServerVerifyServico) : this()
        {
            if (!isqlServerVerifyServico.CheckExistBancoDeDados(nomeBanco))
            {
                isqlServerVerifyServico.CriarBancoDeDados(nomeBanco);
            }

            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IContatoRepositorio IContatoRepositorio => new ContatoRepositorio(this);

        public IStoredEventRepositorio IStoredEventRepositorio => new StoredEventRepositorio(this);

        public virtual void RollbackTransaction()
        {
            if (_transaction != null)
                _transaction.Rollback();

            _transaction = null;
        }
        public bool Commit()
        {
            bool commitSucess;

            try
            {
                _transaction.Commit();
                commitSucess = true;
            }
            catch
            {
                RollbackTransaction();
                commitSucess = false;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
            }

            return commitSucess;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }
        private void dispose(bool disposing)
        {
            if (!disposing)
            {
                if (_disposed)
                {
                    if (_transaction == null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }
        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
