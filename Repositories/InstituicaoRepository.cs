using weapi.Event_.Contexts;
using weapi.Event_.Domains;
using weapi.Event_.Interfaces;

namespace weapi.Event_.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {


        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Cadastrar(Instituicao instituicao)
        {
            _eventContext.Instituicao.Add(instituicao);

            _eventContext.SaveChanges();
        }
    }
}
