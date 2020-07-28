using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using CentralErros.Api.Extensions;
using CentralErros.Api.ViewModels;
using CentralErros.Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CentralErros.Api.Controllers
{
    [Route("api")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController(SignInManager<IdentityUser> signInManager, 
                              UserManager<IdentityUser> userManager, 
                              IOptions<AppSettings> appSettings,
                              INotificador notificador) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult> Registrar(RegistroUsuarioViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Nome,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Senha);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(await GerarJwt(user.Email));
            }

            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse(registerUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUsuarioViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuarioIdentity = await _userManager.FindByEmailAsync(loginUser.Email);
            var result = await _signInManager.PasswordSignInAsync(usuarioIdentity.UserName, loginUser.Senha, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GerarJwt(loginUser.Email));
            }

            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(loginUser);
            }

            NotificarErro("Usuário ou Senha incorretos");
            return CustomResponse(loginUser);
        }

        private async Task<LoginResponseViewModel> GerarJwt(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                TokenAcesso = encodedToken,
                ExpiraEm = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                TokenUsuario = new TokenUsuarioViewModel()
                {
                    Id = usuario.Id,
                    Email = usuario.Email
                }
            };

            return response;
        }
    }
}