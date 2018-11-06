using Agenda.Dominio.Interfaces.Validacoes.ContatoTelefone;
using FluentValidation.Results;

namespace Agenda.Dominio.Commands.ContatoTelefone
{
    public class RegistrarNovoContatoTelefoneCommand : ContatoTelefoneCommand
    {
        private readonly IRegistrarNovoContatoTelefoneCommandValidacao registrarNovoContatoTelefoneCommandValidacao;
        public RegistrarNovoContatoTelefoneCommand(IRegistrarNovoContatoTelefoneCommandValidacao registrarNovoContatoTelefoneCommandValidacao, string telefone)
        {
            this.registrarNovoContatoTelefoneCommandValidacao = registrarNovoContatoTelefoneCommandValidacao;
            Telefone = telefone;
        }

        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }
        public override ValidationResult ObterValidationResult()
        {
            ValidationResult = registrarNovoContatoTelefoneCommandValidacao.Validate(this);

            return ValidationResult;
        }
    }
}
