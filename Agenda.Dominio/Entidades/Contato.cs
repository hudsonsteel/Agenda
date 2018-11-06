using Agenda.Dominio.Core.Interface.Entidades;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Agenda.Dominio.Entidades
{
    [Dapper.Contrib.Extensions.Table("AgendaTelefonica.dbo.Contato")]
    public class Contato : IEntidade
    {
        public Contato()
        {
            //if (ContatoTelefones == null)
            //    ContatoTelefones = new List<ContatoTelefone>();
            //if (ContatoEmails == null)
            //    ContatoEmails = new List<ContatoEmail>();
        }
        public Contato(string nome) : this()
        {
            Nome = nome;
            DtCadastro = DateTime.Now;
        }
        [Key]
        public long IdContato { get; set; }
        public string Nome { get; private set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtExcluido { get; set; }
        [Write(false)]
        public List<ContatoTelefone> ContatoTelefones { get; set; }
        [Write(false)]
        public List<ContatoEmail> ContatoEmails { get; set; }
    }
}
