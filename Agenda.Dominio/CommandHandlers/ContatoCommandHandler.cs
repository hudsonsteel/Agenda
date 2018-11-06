using Agenda.Dominio.Commands.Contato;
using Agenda.Dominio.Core.Bus;
using Agenda.Dominio.Core.Notificacoes;
using Agenda.Dominio.Entidades;
using Agenda.Dominio.Events.Contato;
using Agenda.Dominio.Events.ContatoEmail;
using Agenda.Dominio.Events.ContatoTelefone;
using Agenda.Dominio.Interfaces.Repositorio;
using Agenda.Dominio.Interfaces.Uow;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agenda.Dominio.CommandHandlers
{
    public class ContatoCommandHandler
        : CommandHandler
        , IRequestHandler<RegistrarNovoContatoCommand>
    {
        private readonly IContatoRepositorio contatoRepositorio;
        private readonly IContatoEmailRespositorio contatoEmailRespositorio;
        private readonly IContatoTelefoneRepositorio contatoTelefoneRespositorio;
        public ContatoCommandHandler(IContatoRepositorio contatoRepositorio, IContatoEmailRespositorio contatoEmailRespositorio, IContatoTelefoneRepositorio contatoTelefoneRespositorio, IUnityOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notificacao) : base(uow, bus, notificacao)
        {
            this.contatoEmailRespositorio = contatoEmailRespositorio;
            this.contatoTelefoneRespositorio = contatoTelefoneRespositorio;
            this.contatoRepositorio = contatoRepositorio;
        }

        public Task Handle(RegistrarNovoContatoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.CompletedTask;
            }

            #region Contato
            var contato = new Contato(request.Nome);
            contatoRepositorio.Add(contato);
            #endregion

            #region Contato E-mail
            if (request._contatoEmailValidationResults.Any(x => x.IsValid))
            {
                List<ContatoEmail> contatoEmails = new List<ContatoEmail>();
                foreach (var email in request.Emails)
                {
                    var contatoEmail = new ContatoEmail(email, contato.IdContato);
                    contatoEmailRespositorio.Add(contatoEmail);
                    contatoEmails.Add(contatoEmail);
                }
                contato.ContatoEmails = contatoEmails;
            }
            #endregion

            #region Contato Telefone
            if (request._contatoTelefoneValidationResults.Any(x => x.IsValid))
            {
                List<ContatoTelefone> contatoTelefones = new List<ContatoTelefone>();
                foreach (var telefone in request.Telefones)
                {
                    var contatoTelefone = new ContatoTelefone(telefone, contato.IdContato);
                    contatoTelefoneRespositorio.Add(contatoTelefone);
                    contatoTelefones.Add(contatoTelefone);
                }
                contato.ContatoTelefones = contatoTelefones;
            }
            #endregion

            if (Commit())
            {
                _bus.RaiseEvent(new RegistradoContatoEvent(contato.IdContato, request.Nome, contato.DtCadastro, null));

                if (request._contatoEmailValidationResults.Any(x => x.IsValid))
                {
                    foreach (var contatoEmail in contato.ContatoEmails)
                    {
                        _bus.RaiseEvent(new RegistradoContatoEmailEvent(
                        contatoEmail.IdContatoEmail,
                        contatoEmail.IdContato,
                        contatoEmail.Email,
                        contatoEmail.DtCadastro,
                        contato.DtCadastro));
                    }
                }


                if (request._contatoTelefoneValidationResults.Any(x => x.IsValid))
                {
                    foreach (var contatoTelefone in contato.ContatoTelefones)
                    {
                        _bus.RaiseEvent(new RegistradoContatoTelefoneEvent(
                          contatoTelefone.IdContatoTelefone
                        , contatoTelefone.IdContato
                        , contatoTelefone.Telefone
                        , contatoTelefone.DtCadastro
                        , contatoTelefone.DtExcluido));
                    }
                }

            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            contatoRepositorio.Dispose();
        }
    }
}
