using Templ4te.V1.Domain.Interfaces;

namespace Templ4te.V1.Domain.Usuarios.Interfaces
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        //Usuario Autenticar(string cpf, string senha);
        //Usuario ObterPorCpf(string cpf);
        void Remover(int id);
    }
}