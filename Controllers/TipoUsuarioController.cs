using Microsoft.AspNetCore.Mvc;
using weapi.Event_.Domains;
using weapi.Event_.Interfaces;
using weapi.Event_.Repositories;

namespace weapi.Event_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TipoUsuarioController : Controller
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }


        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception e )
            {

                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("ListTypes")]

        public IActionResult GetBylist() 
        {
            List<TipoUsuario>list = _tipoUsuarioRepository.Listar();

            return StatusCode(200, list);
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update (Guid id , TipoUsuario tipo)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipo);
                return NoContent();
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }

    }

}
