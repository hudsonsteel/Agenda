using Agenda.Dominio.Core.Events;
using Agenda.Dominio.Interfaces.Repositorio;
using Agenda.Dominio.Interfaces.Uow;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.Repositorio.EventSourcing
{
    public class StoredEventRepositorio : RepositorioBase, IStoredEventRepositorio
    {
        private readonly IUnityOfWork _unityOfWork;

        public StoredEventRepositorio(IUnityOfWork unityOfWork) : base(unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public IList<StoredEvent> All(long aggregateId)
        {
            return (from e in _unityOfWork.IStoredEventRepositorio.GetAll() where e.AggregateId == aggregateId select e).ToList();
        }
        public void Store(StoredEvent theEvent)
        {
            _unityOfWork.IStoredEventRepositorio.Add(theEvent);
            _unityOfWork.Commit();
        }
        public ICollection<StoredEvent> GetAll()
        {
            return _unityOfWork.IStoredEventRepositorio.GetAll();
        }

        public void Add(StoredEvent entidade)
        {
            var sb = new System.Text.StringBuilder(277);
            sb.AppendLine(@"INSERT INTO [dbo].[StoredEvent]");
            sb.AppendLine(@"           ([Id]");
            sb.AppendLine(@"           ,[Dados]");
            sb.AppendLine(@"           ,[Usuario]");
            sb.AppendLine(@"           ,[MensagemTipo]");
            sb.AppendLine(@"           ,[AggregateId]");
            sb.AppendLine(@"           ,[DataCadastro])");
            sb.AppendLine(@"     VALUES");
            sb.AppendLine(@"           (@Id");
            sb.AppendLine(@"           ,@Dados");
            sb.AppendLine(@"           ,@Usuario");
            sb.AppendLine(@"           ,@MensagemTipo");
            sb.AppendLine(@"           ,@AggregateId");
            sb.AppendLine(@"           ,@DataCadastro)");

            connection.Query(sb.ToString()
                , param: new
                {
                    Id = entidade.Id
                    ,
                    Dados = entidade.Dados
                    ,
                    Usuario = entidade.Usuario
                    ,
                    MensagemTipo = entidade.MensagemTipo
                    ,
                    AggregateId = entidade.AggregateId
                    ,
                    DataCadastro = entidade.DataCadastro
                }
                , transaction: transaction);
        }
    }
}
