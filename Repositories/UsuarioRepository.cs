using weapi.Event_.Contexts;
using weapi.Event_.Domains;
using weapi.Event_.Interfaces;
using weapi.Event_.Ultils;

namespace weapi.Event_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario user = _eventContext.Usuario
                     .Select(u => new Usuario
                     {
                         IdUsuario = u.IdUsuario,
                         Nome = u.Nome,
                         Email = u.Email,
                         TipoUsuario = new TipoUsuario
                         {
                             IdTipoUsuario = u.IdTipoUsuario,
                             Titulo = u.TipoUsuario!.Titulo
                         }
                     })
                     .FirstOrDefault(u => u.IdUsuario == id)!;

                if (user != null)
                {
                    return user;
                }

                return null!;
            }

            catch (Exception)
            {

                throw;
            }

        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario user = _eventContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,
                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (user != null)
                {
                    bool confere = Criptografia.CompararHash(senha, user.Senha!);

                    if (confere)
                    {
                        return user;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Add(usuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
