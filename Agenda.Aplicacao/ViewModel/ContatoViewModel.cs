using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Aplicacao.ViewModel
{
    public class ContatoViewModel
    {
        public long IdContato { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Tamanho máximo do campo é de 100 caracteres.")]
        [MinLength(4, ErrorMessage = "Tamanho mínimo de caracteres é de 4 digitos.")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtExcluido { get; set; }

        public ContatoTelefoneViewModel ContatoTelefone { get; set; }
        public ContatoEmailViewModel ContatoEmail { get; set; }


        [Display(Name = "Telefones")]
        public List<ContatoTelefoneViewModel> ContatoTelefones { get; set; }
        [Display(Name = "Emails")]
        public List<ContatoEmailViewModel> ContatoEmails { get; set; }
    }
}
