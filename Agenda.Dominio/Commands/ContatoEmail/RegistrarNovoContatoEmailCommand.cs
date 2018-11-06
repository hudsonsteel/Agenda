using Agenda.Dominio.Interfaces.Validacoes.Contato;
using FluentValidation.Results;

namespace Agenda.Dominio.Commands.ContatoEmail
{
    public class RegistrarNovoContatoEmailCommand : ContatoEmailCommand
    {
        private readonly IRegistrarNovoContatoEmailCommandValidacao registarNovoContatoEmailCommandValidacao;
        public RegistrarNovoContatoEmailCommand(IRegistrarNovoContatoEmailCommandValidacao registarNovoContatoEmailCommandValidacao, string email)
        {
            this.registarNovoContatoEmailCommandValidacao = registarNovoContatoEmailCommandValidacao;
            Email = email;
        }
        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }
        public override ValidationResult ObterValidationResult()
        {
            ValidationResult = registarNovoContatoEmailCommandValidacao.Validate(this);

            return ValidationResult;
        }
    }
}
