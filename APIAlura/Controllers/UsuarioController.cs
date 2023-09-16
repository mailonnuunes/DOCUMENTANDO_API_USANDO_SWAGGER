

using APIAlura.Dto;
using APIAlura.Entity;
using APIAlura.Enums;
using APIAlura.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAlura.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {


        private IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioRepository usuarioRepository, ILogger<UsuarioController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;

        }

        /// <summary>
        /// Obtem todos os usuarios com pedidos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador},{Permissoes.Funcionario}" )]
        [HttpGet("obter-todos-com-pedidos/{id}")]
        public IActionResult ObterTodosComPedidos([FromRoute] int id)
        {
            return Ok(_usuarioRepository.ObterComPedidos(id));

        }
        /// <summary>
        ///  Obtem todos os usuarios que estao no banco de dados
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("Obter-todos-os-usuarios")]
        public IActionResult ChamarTodosUsuarios()
        {

            try
            {
                return Ok(_usuarioRepository.ObterTodos());
            } catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} -  Exception forcada");
                return BadRequest();
            }
        }
        /// <summary>
        ///  Busca um usuario com base no ID no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador},{Permissoes.Funcionario}")]
        [HttpGet("Obter-usuario-por-id/{id}")]
        public IActionResult ChamarUsuarioID([FromRoute]int id)
        {
            return Ok(_usuarioRepository.ObterPorId(id));
        }
        /// <summary>
        /// Cadastra um usuario no banco de dados
        /// </summary>
        /// <param name="usuarioDto"></param>
        /// <returns></returns>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador},{Permissoes.Funcionario}")]
        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody]CadastrarUsuarioDto usuarioDto)
        {


            _usuarioRepository.Cadastrar(new Usuario(usuarioDto));
            var mensagem = $"Usuario criado com sucesso! | Nome: {usuarioDto.Nome}";
            _logger.LogWarning(mensagem);
            return Ok(mensagem);

        }
        /// <summary>
        /// Edita um usuario no banco de dados
        /// </summary>
        /// <param name="usuarioDto"></param>
        /// <returns></returns>
        [Authorize]
        [Authorize(Roles =$"{Permissoes.Administrador},{Permissoes.Funcionario}")]
        [HttpPut]
        public IActionResult EditarUsuario([FromBody]AlterarUsuarioDto usuarioDto)
        {
            _usuarioRepository.Editar(new Usuario(usuarioDto));
            return Ok("Usuario editado com sucesso!");
        }
        /// <summary>
        /// Exclui um usuario do banco de dados com base no ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}")]
        [HttpDelete]
        public IActionResult ExcluirUsuario(int id)
        {
            _usuarioRepository.Deletar(id);
            return Ok("Usuario deletado com sucesso!");
        }
    }
}
