using Templ4te.V1.Data.Context;
using Templ4te.V1.Domain.Usuarios;
using Templ4te.V1.Domain.Usuarios.Interfaces;

namespace Templ4te.V1.Data
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ContextEFC contextEFC)
            :base(contextEFC)
        {

        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Db.Enderecos.Add(endereco);
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            Db.Enderecos.Update(endereco);
        }
        
    }
}
