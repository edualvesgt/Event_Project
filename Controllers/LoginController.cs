using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using weapi.Event_.Domains;
using weapi.Event_.Interfaces;
using weapi.Event_.Repositories;
using weapi.Event_.ViewModels;

namespace weapi.Event_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class LoginController : Controller
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel usuario)
        {
            try
            {
                Usuario login = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (login == null)
                {
                    return StatusCode(401, "Senha ou Email Invalidos");
                }
               

                //Tokem: 

                //1º Definir as informacoes(Claims) que serao fornecidos no token (PAYLOAD)
                var claims = new[]
                {

                    new Claim(JwtRegisteredClaimNames.Name,login.Nome!),
                    new Claim(JwtRegisteredClaimNames.Email,login.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti,login.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role,login.TipoUsuario!.Titulo!)

                    //Existe a possibilidade de criar uma claim personalizada
                    //new Claim("Claim Personalizada", "Valor da Claim Personalizada")
                };

                //2º - Definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projeto-webapib-Event-dev-chave-de-autenticacao"));


                //3º - Definir as credenciais do token(HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar token
                var token = new JwtSecurityToken
                    (
                        //Emissor do token
                        issuer: "weapi.Event+",

                        //Destinatario
                        audience: "weapi.Event+",

                        //dados definidos nas claims(informacoes)
                        claims: claims,

                        //Tempo de expiracao do token
                        expires: DateTime.Now.AddMinutes(5),

                        //credenciais do token
                        signingCredentials: creds
                    );


                //5º - Retirnar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

