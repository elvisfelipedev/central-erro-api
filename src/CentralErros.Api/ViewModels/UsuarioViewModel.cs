using System.ComponentModel.DataAnnotations;

namespace CentralErros.Api.ViewModels
{
    public class RegistroUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre acima de {2} caracteres", MinimumLength = 5)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmarSenha { get; set; }
    }

    public class LoginUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre acima de {2} caracteres", MinimumLength = 5)]
        public string Senha { get; set; }
    }

    public class TokenUsuarioViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
    }

    public class LoginResponseViewModel
    {
        public string TokenAcesso { get; set; }
        public double ExpiraEm { get; set; }
        public TokenUsuarioViewModel TokenUsuario { get; set; }
    }
}