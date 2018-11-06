using Agenda.Dominio.Core.Interface.Entidades;
using Dapper.Contrib.Extensions;
using System;

namespace Agenda.Dominio.Entidades
{
    [Table("AgendaTelefonica.dbo.ContatoTelefone")]
    public class ContatoTelefone : IEntidade
    {
        public ContatoTelefone()
        {

        }
        public ContatoTelefone(string telefone, long idContato) : this()
        {
            Telefone = telefone;
            this.IdContato = idContato;
            this.DtCadastro = DateTime.Now;
        }
        [Dapper.Contrib.Extensions.Key]
        public long IdContatoTelefone { get;  set; }
        public long IdContato { get;  set; }
        public string Telefone { get;  set; }
        public DateTime DtCadastro { get;  set; }
        public DateTime? DtExcluido { get;  set; }
    }
}
