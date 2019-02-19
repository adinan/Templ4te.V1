using Templ4te.V1.Data.Context;
using Templ4te.V1.Domain.Interfaces;
using Templ4te.V1.Domain.Usuarios;

namespace Templ4te.V1.Data
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ContextEFC contextEFC)
            :base(contextEFC)
        {

        }
    }
}
