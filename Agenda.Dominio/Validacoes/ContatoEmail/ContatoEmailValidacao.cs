using Agenda.Dominio.Commands.ContatoEmail;
using FluentValidation;

namespace Agenda.Dominio.Validacoes.ContatoEmail
{
    public abstract class ContatoEmailValidacao<T> : AbstractValidator<T> where T : ContatoEmailCommand
    {
        protected void ValdiarIdContatoTelefone()
        {
            RuleFor(c => c.IdContatoEmail)
            .Must((c) => c > 0)
            .WithMessage("O identificador do telefone não é valido.");
        }
        protected void ValidarEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Informe um endereço de e-mail.")
                .EmailAddress()
                .WithMessage("Digite um e-mail válido.");
        }
    }
}
