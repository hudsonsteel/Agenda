using Agenda.Dominio.Commands.ContatoTelefone;
using FluentValidation;

namespace Agenda.Dominio.Validacoes.ContatoTelefone
{
    public abstract class ContatoTelefoneValidacao<T> : AbstractValidator<T> where T : ContatoTelefoneCommand
    {
        protected void ValdiarIdContatoTelefone()
        {
            RuleFor(c => c.IdContatoTelefone)
            .Must((c) =>  c > 0)
            .WithMessage("O identificador do telefone não é valido.");
        }
        protected void ValidarTelefone()
        {
            RuleFor(c => c.Telefone)
                .NotEmpty()
                .WithMessage("Informe um telefone.")
                .MinimumLength(8)
                .WithMessage("Minímo de 8 caracteres")
                .MaximumLength(20)
                .WithMessage("Máximo de 20 caracteres");
        }
    }
}
