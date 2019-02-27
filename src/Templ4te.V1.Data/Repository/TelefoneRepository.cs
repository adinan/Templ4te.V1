using Templ4te.V1.Data.Context;
using Templ4te.V1.Domain.Usuarios;
using Templ4te.V1.Domain.Usuarios.Interfaces;

namespace Templ4te.V1.Data
{
    public class TelefoneRepository : RepositoryBase<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(ContextEFC contextEFC)
            : base(contextEFC)
        {

        }
    }
}
