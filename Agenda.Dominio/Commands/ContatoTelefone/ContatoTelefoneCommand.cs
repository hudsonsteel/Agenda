using Agenda.Dominio.Core.Commands;
using System;

namespace Agenda.Dominio.Commands.ContatoTelefone
{
    public abstract class ContatoTelefoneCommand : Command
    {
        public long IdContatoTelefone { get; set; }
        public long IdContato { get; set; }
        public string Telefone { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtExcluido { get; set; }
    }
}
