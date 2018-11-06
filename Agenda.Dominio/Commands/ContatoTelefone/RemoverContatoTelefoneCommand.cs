using Agenda.Dominio.Interfaces.Validacoes.ContatoTelefone;
using FluentValidation.Results;

namespace Agenda.Dominio.Commands.ContatoTelefone
{
    public class RemoverContatoTelefoneCommand : ContatoTelefoneCommand
    {
        private readonly IRemoverContatoTelefoneComamndValidacao removerContatoTelefoneComamndValidacao;

        public RemoverContatoTelefoneCommand(IRemoverContatoTelefoneComamndValidacao removerContatoTelefoneComamndValidacao, long idContatoTelefone)
        {
            this.removerContatoTelefoneComamndValidacao = removerContatoTelefoneComamndValidacao;
            IdContatoTelefone = idContatoTelefone;
        }

        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }

        public override ValidationResult ObterValidationResult()
        {
            ValidationResult = removerContatoTelefoneComamndValidacao.Validate(this);

            return ValidationResult;
        }
    }
}
