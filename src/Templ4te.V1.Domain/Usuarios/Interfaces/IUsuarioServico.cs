using Templ4te.V1.Domain.Interfaces;

namespace Templ4te.V1.Domain.Usuarios.Interfaces
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(int id);

    }
}