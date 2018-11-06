using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces.Repositorio;
using Agenda.Dominio.Interfaces.Uow;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Linq;

namespace Agenda.Infra.Repositorio.Contato
{
    public class ContatoEmailRepositorio : RepositorioBase, IContatoEmailRespositorio
    {
        public ContatoEmailRepositorio(IUnityOfWork iunityOfWork) : base(iunityOfWork)
        {
        }

        public void Add(ContatoEmail entidade)
        {
            connection.Insert(entidade, transaction);
        }

        public bool ExistEmailCadastrado(long idContatoEmail)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(@"SELECT ");
            sb.AppendLine(@"	COUNT(*)");
            sb.AppendLine(@"FROM ");
            sb.AppendLine(@"	[AgendaTelefonica].[dbo].[ContatoEmail]");
            sb.AppendLine(@"WHERE");
            sb.AppendLine(@"	DtExcluido IS NULL");
            sb.AppendLine(@"	AND");
            sb.AppendLine(@"	IdContatoEmail = @IdContatoEmail");

            return connection.Query<bool>(sb.ToString(), param: new { IdContatoEmail = idContatoEmail }, transaction: transaction).FirstOrDefault();
        }

        public ContatoEmail Find(long id)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(@"SELECT ");
            sb.AppendLine(@"	*");
            sb.AppendLine(@"FROM ");
            sb.AppendLine(@"	[AgendaTelefonica].[dbo].ContatoEmail");
            sb.AppendLine(@"WHERE");
            sb.AppendLine(@"	IdContatoEmail = @IdContatoEmail");

            return connection.Query<ContatoEmail>(sb.ToString(), param: new { IdContatoEmail = id }, transaction: transaction).FirstOrDefault();
        }

        public void Remove(ContatoEmail entidade)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(@"update [AgendaTelefonica].[dbo].[ContatoEmail] set  DtExcluido = getdate() where IdContatoEmail = @IdContatoEmail");

            connection.Execute(sb.ToString(), param: new { IdContatoEmail = entidade.IdContatoEmail }, transaction: transaction);
        }
    }
}
