using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces.Repositorio;
using Agenda.Dominio.Interfaces.Uow;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Linq;

namespace Agenda.Infra.Repositorio.Contato
{
    public class ContatoTelefoneRepositorio : RepositorioBase, IContatoTelefoneRepositorio
    {
        public ContatoTelefoneRepositorio(IUnityOfWork iunityOfWork) : base(iunityOfWork)
        {
        }

        public void Add(ContatoTelefone entidade)
        {
            connection.Insert(entidade, transaction);
        }

        public bool ExistTelefoneCadastrado(long idContato)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(@"SELECT ");
            sb.AppendLine(@"	COUNT(*)");
            sb.AppendLine(@"FROM ");
            sb.AppendLine(@"	[AgendaTelefonica].[dbo].ContatoTelefone");
            sb.AppendLine(@"WHERE");
            sb.AppendLine(@"	DtExcluido IS NULL");
            sb.AppendLine(@"	AND");
            sb.AppendLine(@"	IdContatoTelefone = @IdContatoTelefone");

            return connection.Query<bool>(sb.ToString(), param: new { IdContatoTelefone = idContato }, transaction: transaction).FirstOrDefault();
        }

        public ContatoTelefone Find(long id)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(@"SELECT ");
            sb.AppendLine(@"	*");
            sb.AppendLine(@"FROM ");
            sb.AppendLine(@"	[AgendaTelefonica].[dbo].ContatoTelefone");
            sb.AppendLine(@"WHERE");
            sb.AppendLine(@"	IdContatoTelefone = @IdContatoTelefone");

            return connection.Query<ContatoTelefone>(sb.ToString(), param: new { IdContatoTelefone = id }, transaction: transaction).First();
        }

        public void Remove(ContatoTelefone entidade)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(@"update [AgendaTelefonica].[dbo].[ContatoTelefone] set  DtExcluido = getdate() where IdContatoTelefone = @IdContatoTelefone");

            connection.Execute(sb.ToString(), param: new { IdContatoTelefone = entidade.IdContatoTelefone }, transaction: transaction);
        }
    }
}
