using System;
using System.ComponentModel.DataAnnotations;

namespace CentralErros.Api.ViewModels
{
    public class LogViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Origem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Ambiente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Level { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Evento { get; set; }

        public bool Arquivar { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public string NomeUsuario { get; set; }
    }
}
