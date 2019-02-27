using Templ4te.V1.Domain.Interfaces;

namespace Templ4te.V1.Domain.Usuarios.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        void AdicionarEndereco(Endereco endereco);
        void AtualizarEndereco(Endereco endereco);
    }
}
