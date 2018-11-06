using Agenda.Dominio.Interfaces.Validacoes.ContatoTelefone;
using FluentValidation.Results;

namespace Agenda.Dominio.Commands.ContatoTelefone
{
    public class AtualizarContatoTelefoneComamnd : ContatoTelefoneCommand
    {
        private readonly IAtualizarContatoTelefoneComamndValidacao atualizarContatoTelefoneComamndValidacao;

        public AtualizarContatoTelefoneComamnd(IAtualizarContatoTelefoneComamndValidacao atualizarContatoTelefoneComamndValidacao, string telefone)
        {
            this.atualizarContatoTelefoneComamndValidacao = atualizarContatoTelefoneComamndValidacao;
            Telefone = telefone;
        }

        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }

        public override ValidationResult ObterValidationResult()
        {
            ValidationResult =  atualizarContatoTelefoneComamndValidacao.Validate(this);

            return ValidationResult;
        }
    }
}
