using APIAlura.Dto;
using APIAlura.Interfaces;
using APIAlura.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIAlura.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {

        private readonly IUsuarioRepository _usuariosRepository;
        private readonly ITokenService _tokenService;

        public LoginController(IUsuarioRepository usuariosRepository, ITokenService tokenService)
        {
            _usuariosRepository = usuariosRepository;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Faz a authenticacao utilizando login e senha e gera o token
        /// </summary>
        /// <param name="usuarioDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Autenticar([FromBody] LoginDto usuarioDto)
        {
            var usuario = _usuariosRepository.ObterPorNomeUsuarioESenha(
                usuarioDto.NomeUsuario, usuarioDto.Senha
                );
            if (usuario == null)
                return NotFound(new { mensagem = "Usuario ou senha inválidos " });
            var token = _tokenService.GerarToken(usuario);

            usuario.Senha = null;

            return Ok(new
            {
                Usuario = usuario,
                token = token
            });
        }
    }
}
