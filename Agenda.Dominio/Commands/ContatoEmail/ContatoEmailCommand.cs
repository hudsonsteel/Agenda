using Agenda.Dominio.Core.Commands;
using System;

namespace Agenda.Dominio.Commands.ContatoEmail
{
    public abstract class ContatoEmailCommand : Command
    {
        public long IdContatoEmail { get; set; }
        public long IdContato { get; set; }
        public string Email { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtExcluido { get; set; }
    }
}
