using Agenda.Dominio.Core.Interface.Entidades;
using Dapper.Contrib.Extensions;
using System;

namespace Agenda.Dominio.Entidades
{
    [Table("AgendaTelefonica.dbo.ContatoEmail")]
    public class ContatoEmail : IEntidade
    {
        public ContatoEmail()
        {

        }
        public ContatoEmail(string email, long idContato)
        {
            Email = email;
            this.IdContato = idContato;
            DtCadastro = DateTime.Now;
        }
        [Key]
        public long IdContatoEmail { get; set; }
        public long IdContato { get;  set; }
        public string Email { get;  set; }
        public DateTime DtCadastro { get;  set; }
        public DateTime? DtExcluido { get;  set; }
    }
}
