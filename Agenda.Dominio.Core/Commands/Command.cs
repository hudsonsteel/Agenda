using Agenda.Dominio.Core.Events;
using FluentValidation.Results;
using System;

namespace Agenda.Dominio.Core.Commands
{
    public abstract class Command : Mensagem
    {
        public DateTime TimeStamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            TimeStamp = DateTime.Now;
            ValidationResult = new ValidationResult();
        }
        public abstract bool IsValid();
        public virtual  ValidationResult ObterValidationResult()
        {
            return null;
        }
    }
}
