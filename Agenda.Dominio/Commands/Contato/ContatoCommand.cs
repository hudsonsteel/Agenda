using Agenda.Dominio.Core.Commands;
using System;
using System.Collections.Generic;

namespace Agenda.Dominio.Commands.Contato
{
    public abstract class ContatoCommand : Command
    {
        public long IdContato { get; protected set; }
        public string Nome { get; protected set; }
        public List<string> Emails { get; protected set; }
        public List<string> Telefones { get; protected set; }
        public DateTime DtCadastro { get; protected set; }
        public DateTime? DtExcluido { get; protected set; }
    }
}
