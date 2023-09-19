using weapi.Event_.Domains;

namespace weapi.Event_.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string email,string senha);
    }
}
