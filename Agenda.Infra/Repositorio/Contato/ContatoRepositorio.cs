using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces.Repositorio;
using Agenda.Dominio.Interfaces.Uow;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.Repositorio
{
    public class ContatoRepositorio : RepositorioBase, IContatoRepositorio
    {
        public ContatoRepositorio(IUnityOfWork iunityOfWork) : base(iunityOfWork)
        {
        }

        public void Add(Dominio.Entidades.Contato entidade)
        {
            entidade.IdContato = connection.Insert(entidade, transaction);
        }

        public ICollection<Dominio.Entidades.Contato> GetAll()
        {
            return connection.GetAll<Dominio.Entidades.Contato>(transaction).ToList();
        }

        public Dominio.Entidades.Contato Find(long id)
        {
            var sb = new System.Text.StringBuilder(352);
            sb.AppendLine(@"SELECT");
            sb.AppendLine(@"	c.*");
            sb.AppendLine(@"	,ce.*");
            sb.AppendLine(@"	,ct.*");
            sb.AppendLine(@"FROM");
            sb.AppendLine(@"	AgendaTelefonica.dbo.Contato as C");
            sb.AppendLine(@"	LEFT JOIN AgendaTelefonica.dbo.ContatoEmail as CE ON CE.IdContato = C.IdContato AND CE.DtExcluido IS NULL");
            sb.AppendLine(@"	LEFT JOIN AgendaTelefonica.dbo.ContatoTelefone as CT ON CT.IdContato = c.IdContato AND CT.DtExcluido IS NULL");
            sb.AppendLine(@"WHERE");
            sb.AppendLine(@"	C.DtExcluido IS NULL");
            sb.AppendLine(@"	AND");
            sb.AppendLine(@"	C.IdContato = @IdContato");

            var lstContatoEmail = new List<ContatoEmail>();
            var lstContatoTelefone = new List<ContatoTelefone>();

            var _contato = connection.Query<Dominio.Entidades.Contato, ContatoEmail, ContatoTelefone, Dominio.Entidades.Contato>(sb.ToString()
                 , map: (contato, contatoEmails, contatoTelefones)
                  =>
                 {
                     if (!lstContatoEmail.Exists(x => x.IdContatoEmail == contatoEmails?.IdContatoEmail) && contatoEmails != null)
                         lstContatoEmail.Add(contatoEmails);

                     if (!lstContatoTelefone.Exists(x => x.IdContatoTelefone == contatoTelefones?.IdContatoTelefone) && contatoTelefones != null)
                         lstContatoTelefone.Add(contatoTelefones);

                     return contato;
                 }, splitOn: "IdContato, IdContatoEmail,IdContatoTelefone"
                 , param: new { IdContato = id }
                 , transaction: transaction).FirstOrDefault();

            _contato.ContatoTelefones = lstContatoTelefone;
            _contato.ContatoEmails = lstContatoEmail;

            return _contato;
        }

        public void Remove(Dominio.Entidades.Contato entidade)
        {
            connection.Delete(entidade);
        }

        public void Update(Dominio.Entidades.Contato entidade)
        {
            connection.Update(entidade);
        }

        public ICollection<Dominio.Entidades.Contato> GetAllAtivos()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(@"SELECT");
            sb.AppendLine(@"	c.*");
            sb.AppendLine(@"	,ce.*");
            sb.AppendLine(@"	,ct.*");
            sb.AppendLine(@"FROM");
            sb.AppendLine(@"	AgendaTelefonica.dbo.Contato as C");
            sb.AppendLine(@"	LEFT JOIN AgendaTelefonica.dbo.ContatoEmail as CE ON CE.IdContato = C.IdContato");
            sb.AppendLine(@"	LEFT JOIN AgendaTelefonica.dbo.ContatoTelefone as CT ON CT.IdContato = c.IdContato");
            sb.AppendLine(@"WHERE");
            sb.AppendLine(@"	C.DtExcluido IS NULL AND CE.DtExcluido IS NULL AND CT.DtExcluido IS NULL");


            var lst = connection.Query<Dominio.Entidades.Contato, List<ContatoEmail>, List<ContatoTelefone>, Dominio.Entidades.Contato>(sb.ToString()
                 , map: (contato, contatoEmails, contatoTelefones)
                  =>
                  {
                      contato.ContatoEmails = contatoEmails;
                      contato.ContatoTelefones = contatoTelefones;

                      return contato;
                  }, splitOn: "IdContato,IdContato,IdContato"
                  , transaction: transaction).ToList();

            return lst;
        }
    }
}
