using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Aplicacao.ViewModel
{
    public class ContatoEmailViewModel
    {
        public long IdContatoEmail { get; set; }
        public long IdContato { get; set; }
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtExcluido { get; set; }
    }
}
