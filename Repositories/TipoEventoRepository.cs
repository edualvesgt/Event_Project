using weapi.Event_.Contexts;
using weapi.Event_.Domains;
using weapi.Event_.Interfaces;

namespace weapi.Event_.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {

        private readonly EventContext _eventContext;

        public TipoEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento update = _eventContext.TipoEvento.FirstOrDefault(u => u.IdTipoEvento == id)!;
            update.Titulo = tipoEvento.Titulo;

            _eventContext.TipoEvento.Update(update);
            _eventContext.SaveChanges();
            
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            TipoEvento searchById = _eventContext.TipoEvento.FirstOrDefault(s => s.IdTipoEvento == id)!;
            if (searchById != null)
            {
                return searchById;
            }

            return null!;
        }

        public void Cadastrar(TipoEvento tipoEvento)
        {
            _eventContext.TipoEvento.Add(tipoEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TipoEvento find = _eventContext.TipoEvento.Find(id)!;

            _eventContext.TipoEvento.Remove(find);
            _eventContext.SaveChanges();


        }

        public List<TipoEvento> Listar()
        {
            List<TipoEvento> list = _eventContext.TipoEvento.ToList();
            return list;
        }
    }
}
