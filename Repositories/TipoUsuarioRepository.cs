using weapi.Event_.Contexts;
using weapi.Event_.Domains;
using weapi.Event_.Interfaces;

namespace weapi.Event_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario searchById = _eventContext.TipoUsuario
               .Select(t => new TipoUsuario
               {
                   IdTipoUsuario = t.IdTipoUsuario,
                   Titulo = t.Titulo,
               })
               .FirstOrDefault(t => t.IdTipoUsuario == id)!;

                if (searchById != null )
                {
                    return searchById;
                }

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
               
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            _eventContext.TipoUsuario.Add(tipoUsuario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuario> Listar()
        {
            List<TipoUsuario> list = _eventContext.TipoUsuario.ToList();

            return list;

            
        }
    }
}
