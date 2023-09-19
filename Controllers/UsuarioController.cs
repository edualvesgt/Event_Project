using Microsoft.AspNetCore.Mvc;
using weapi.Event_.Domains;
using weapi.Event_.Interfaces;
using weapi.Event_.Repositories;

namespace weapi.Event_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]

        public IActionResult GetbyId(Guid id)
        {

            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
