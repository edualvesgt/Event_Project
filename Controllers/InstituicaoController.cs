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
    public class InstituicaoController : ControllerBase
    {

        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }
        [HttpPost]

        public IActionResult Post (Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);
                return StatusCode(201);
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }

    }
}
