using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Aplicacao.ViewModel
{
    public class ContatoTelefoneViewModel
    {
        public long IdContatoTelefone { get; set; }
        public long IdContato { get; set; }
        [MinLength(8, ErrorMessage = "Minímo de 8 caracteres.")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres.")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtExcluido { get; set; }
    }
}
