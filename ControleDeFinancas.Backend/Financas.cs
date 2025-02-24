using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.MicrosoftExtensions;

namespace ControleDeFinancas.Backend
{
    public class Financas
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string Valor {  get; set; }

        public string Tipo { get; set; }

        public string Data { get; set; }
    }

    public class CriarAtualizar
    {

        [Required(ErrorMessage = "O campo não foi preenchido corretamente")]
        [MinLength(1, ErrorMessage = "O campo deve conter pelo menos uma letra.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo não foi preenchido corretamente")]
        [MinLength(1, ErrorMessage = "O campo deve conter pelo menos uma letra.")]

        public string Valor { get; set; }

        [Required(ErrorMessage = "O campo não foi preenchido corretamente")]
        [MinLength(1, ErrorMessage = "O campo deve conter pelo menos uma letra.")]

        public string Tipo { get; set; }

        [Required(ErrorMessage = "O campo não foi preenchido corretamente")]
        [MinLength(1, ErrorMessage = "O campo deve conter pelo menos uma letra.")]

        public string Data { get; set; }
    }
}
