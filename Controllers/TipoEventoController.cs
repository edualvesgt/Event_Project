using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using weapi.Event_.Domains;
using weapi.Event_.Interfaces;
using weapi.Event_.Repositories;

namespace weapi.Event_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        [HttpPost]

        public IActionResult Post (TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(tipoEvento);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet ("{id}")]
        public IActionResult GetById (Guid id) 
        {
            try
            {
                return Ok(_tipoEventoRepository.BuscarPorId(id));
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListById")]
        public IActionResult GetList()
        {
            try
            {
                List<TipoEvento> list = _tipoEventoRepository.Listar();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest (e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEvento);
                return StatusCode(200);
            }
            catch (Exception e )
            {
                return BadRequest(e.Message) ;
            }
        }
    }
}
