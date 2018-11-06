using Agenda.Dominio.Commands.Contato;
using FluentValidation;
using System;

namespace Agenda.Dominio.Validacoes.Contato
{
    public abstract class ContatoValidacao<T> : AbstractValidator<T> where T : ContatoCommand
    {
        protected void ValidarIdContato()
        {
            RuleFor(c => c.IdContato)
                .Must(DeveSerMaiorQueZero)
                .WithMessage("O Id do Contato é inválido.");
        }
        protected void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome está vazio, obrigatório o preenchimento.")
                .Length(3, 150).WithMessage("O nome deve ter no minimo 3 caracteres e no máximo 150.");
        }

        protected void ValidarDataCadastro()
        {
            RuleFor(c => c.DtCadastro)
                .Must(s => s != new DateTime())
            .WithMessage("Data Cadastro inválida.");
        }

        protected bool DeveSerMaiorQueZero(long idContato)
        {
            return idContato > 0;
        }
    }
}
