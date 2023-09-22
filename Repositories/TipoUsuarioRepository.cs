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
            //Recebe salva a busca feita pela expressao no obj user e igualando ela ao recebetido 
            TipoUsuario user = _eventContext.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;
            user.Titulo = tipoUsuario.Titulo;

            _eventContext.TipoUsuario.Update(user);
            _eventContext.SaveChanges();
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
            TipoUsuario find = _eventContext.TipoUsuario.Find(id)!;

            _eventContext.TipoUsuario.Remove(find);

            _eventContext.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            List<TipoUsuario> list = _eventContext.TipoUsuario.ToList();

            return list;

            
        }
    }
}
