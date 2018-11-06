using Agenda.Dominio.Commands.ContatoEmail;
using Agenda.Dominio.Commands.ContatoTelefone;
using Agenda.Dominio.Interfaces.Validacoes.Contato;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Dominio.Commands.Contato
{
    public class RegistrarNovoContatoCommand : ContatoCommand
    {
        private readonly IRegistrarNovoContatoCommandValidacao registarNovoContatoCommandValidacao;
        private readonly List<RegistrarNovoContatoTelefoneCommand> registrarNovoContatoTelefoneCommands;
        private readonly List<RegistrarNovoContatoEmailCommand> registrarNovoContatoEmailCommands;

        public List<ValidationResult> _contatoEmailValidationResults;
        public List<ValidationResult> _contatoTelefoneValidationResults;
        public RegistrarNovoContatoCommand(List<RegistrarNovoContatoEmailCommand> registrarNovoContatoEmailCommands, List<RegistrarNovoContatoTelefoneCommand> registrarNovoContatoTelefoneCommands, IRegistrarNovoContatoCommandValidacao registarNovoContatoCommandValidacao, string nome)
        {
            this.registrarNovoContatoEmailCommands = registrarNovoContatoEmailCommands;
            this.registrarNovoContatoTelefoneCommands = registrarNovoContatoTelefoneCommands;
            this.registarNovoContatoCommandValidacao = registarNovoContatoCommandValidacao;
            Nome = nome;
            Telefones = registrarNovoContatoTelefoneCommands.Select(x => x.Telefone).ToList();
            Emails = registrarNovoContatoEmailCommands.Select(x => x.Email).ToList();
        }

        public override bool IsValid()
        {
            var resultContato = registarNovoContatoCommandValidacao.Validate(this);
            _contatoTelefoneValidationResults = registrarNovoContatoTelefoneCommands.Select(x => x.ObterValidationResult()).ToList();
            _contatoEmailValidationResults = registrarNovoContatoEmailCommands.Select(x => x.ObterValidationResult()).ToList();

            resultContato.Errors.ToList().ForEach(x => ValidationResult.Errors.Add(x));
            _contatoTelefoneValidationResults.ForEach(l => l.Errors.ToList().ForEach(x => ValidationResult.Errors.Add(x)));
            _contatoEmailValidationResults.ForEach(l => l.Errors.ToList().ForEach(x => ValidationResult.Errors.Add(x)));

            return resultContato.IsValid && (_contatoTelefoneValidationResults.Any(x => x.IsValid) || _contatoEmailValidationResults.Any(x => x.IsValid));
        }
    }
}
