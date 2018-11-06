using Agenda.Dominio.Interfaces.Validacoes.ContatoEmail;

namespace Agenda.Dominio.Commands.ContatoEmail
{
    public class RemoverContatoEmailCommand : ContatoEmailCommand
    {
        private readonly IRemoverContatoEmailCommandValidacao removerContatoEmailCommandValidacao;
        public RemoverContatoEmailCommand(IRemoverContatoEmailCommandValidacao removerContatoEmailCommandValidacao, long idContatoEmail)
        {
            this.removerContatoEmailCommandValidacao = removerContatoEmailCommandValidacao;
            IdContatoEmail = idContatoEmail;
        }

        public override bool IsValid()
        {
            ValidationResult = removerContatoEmailCommandValidacao.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
