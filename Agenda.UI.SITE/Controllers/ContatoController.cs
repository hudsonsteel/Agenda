using Agenda.Aplicacao.Interfaces;
using Agenda.Aplicacao.ViewModel;
using Agenda.Dominio.Core.Notificacoes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agenda.UI.SITE.Controllers
{
    public class ContatoController : BaseController
    {
        private readonly IContatoAppService _contatoAppService;
        private static List<ContatoTelefoneViewModel> _contatoTelefoneViewModels;
        private static List<ContatoEmailViewModel> _contatoEmailViewModels;
        private static ContatoViewModel _contatoViewModel;
        private readonly IContatoTelefoneAppService _contatoTelefoneAppService;
        private readonly IContatoEmailAppService _contatoEmailAppService;
        public ContatoController(IContatoEmailAppService contatoEmailAppService, IContatoTelefoneAppService contatoTelefoneAppService, IContatoAppService contatoAppService, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _contatoEmailAppService = contatoEmailAppService;
            _contatoAppService = contatoAppService;
            _contatoTelefoneAppService = contatoTelefoneAppService;
            ViewBag.Detalhe = "";
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_contatoAppService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (_contatoViewModel == null)
                _contatoViewModel = new ContatoViewModel();

            _contatoViewModel.ContatoTelefones = _contatoTelefoneViewModels;
            _contatoViewModel.ContatoEmails = _contatoEmailViewModels;

            ViewBag.Status = "NovoContato";

            return View(_contatoViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContatoViewModel contatoViewModel)
        {
            contatoViewModel = _contatoViewModel;
            _contatoAppService.Registrar(contatoViewModel);

            if (IsValidOperation())
            {
                ViewBag.Sucesso = "Contato Cadastrado!";
                contatoViewModel = new ContatoViewModel();
                _contatoTelefoneViewModels = new List<ContatoTelefoneViewModel>();
                _contatoEmailViewModels = new List<ContatoEmailViewModel>();
                _contatoViewModel = null;
            }

            return View(contatoViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddContatoEmail(ContatoViewModel contatoViewModel)
        {
            if (TryValidateModel(contatoViewModel.ContatoEmail))
            {
                if (_contatoEmailViewModels == null)
                    _contatoEmailViewModels = new List<ContatoEmailViewModel>();

                if (!string.IsNullOrEmpty(contatoViewModel.ContatoEmail.Email?.Trim() ?? "") && !_contatoEmailViewModels.Exists(x => x.Email == contatoViewModel.ContatoEmail.Email))
                {
                    _contatoEmailViewModels.Add(new ContatoEmailViewModel() { Email = contatoViewModel.ContatoEmail.Email });
                    contatoViewModel.ContatoEmail = new ContatoEmailViewModel();
                }
                else { ViewBag.Error = "Ja existe este Email."; }

                if (IsValidOperation())
                    ViewBag.Sucesso = "Email Cadastrado!";

                _contatoViewModel = contatoViewModel;
            }


            return RedirectToAction("Create");
        }
        [HttpGet]
        public IActionResult DeletarEmailLst(string email)
        {
            if (!string.IsNullOrEmpty(email?.Trim() ?? "") && _contatoEmailViewModels.Exists(x => x.Email == email))
            {
                _contatoEmailViewModels.RemoveAll(x => x.Email == email);
            }
            else { ViewBag.Error = "Email não encontrado."; }

            if (IsValidOperation())
                ViewBag.Sucesso = "Email Deletado!";

            return RedirectToAction("Create");
        }
        [HttpGet]
        public IActionResult DeletarEmail(long idContatoEmail, long idContato)
        {
            _contatoEmailAppService.Remover(new ContatoEmailViewModel { IdContatoEmail = idContatoEmail });

            if (IsValidOperation())
                ViewBag.Sucesso = "Email Deletado!";

            return RedirectToAction("EditarContato", new { idContato = idContato });
        }
        [HttpGet]
        public IActionResult DeletarTelefone(long idContatoTelefone, long idContato)
        {
            _contatoTelefoneAppService.Remover(new ContatoTelefoneViewModel { IdContatoTelefone = idContatoTelefone });

            if (IsValidOperation())
                ViewBag.Sucesso = "Telefone Deletado!";

            return RedirectToAction("EditarContato", new { idContato });
        }
        [HttpGet]
        public IActionResult DeletarTelefoneLista(string telefone)
        {
            if (!string.IsNullOrEmpty(telefone?.Trim() ?? "") && _contatoTelefoneViewModels.Exists(x => x.Telefone == telefone))
            {
                _contatoTelefoneViewModels.RemoveAll(x => x.Telefone == telefone);
            }
            else { ViewBag.Error = "Telefone não encontrado."; }

            if (IsValidOperation())
                ViewBag.Sucesso = "Telefone Deletado!";

            return RedirectToAction("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddContatoTelefone(ContatoViewModel contatoViewModel)
        {
            if (TryValidateModel(contatoViewModel.ContatoTelefone))
            {
                if (_contatoTelefoneViewModels == null)
                    _contatoTelefoneViewModels = new List<ContatoTelefoneViewModel>();

                if (!string.IsNullOrEmpty(contatoViewModel.ContatoTelefone.Telefone?.Trim() ?? "") && !_contatoTelefoneViewModels.Exists(x => x.Telefone == contatoViewModel.ContatoTelefone.Telefone))
                {
                    _contatoTelefoneViewModels.Add(new ContatoTelefoneViewModel() { Telefone = contatoViewModel.ContatoTelefone.Telefone });
                    contatoViewModel.ContatoTelefone = new ContatoTelefoneViewModel();
                }
                else { ViewBag.Error = "Ja existe este telefone."; }

                if (IsValidOperation())
                    ViewBag.Sucesso = "Telefone Cadastrado!";

                _contatoViewModel = contatoViewModel;
            }

            return RedirectToAction("Create");
        }
        [HttpGet]
        public IActionResult Detalhe()
        {
            ViewBag.Detalhe = "Detalhe";
            return View(_contatoViewModel);
        }
        [HttpPost]
        public IActionResult DetalheContato(long idContato)
        {
            _contatoViewModel = _contatoAppService.GetById(idContato);

            return RedirectToAction("Detalhe");
        }

        [HttpPost]
        public IActionResult DeletarContato(long idContato)
        {
            _contatoViewModel = _contatoAppService.GetById(idContato);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditarContato(long idContato)
        {
            _contatoViewModel = _contatoAppService.GetById(idContato);

            ViewBag.Status = "EditarContato";

            return View(_contatoViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeletarContatoEmail(long idContato)
        {
            _contatoViewModel = _contatoAppService.GetById(idContato);

            return View(_contatoViewModel);
        }

    }
}