using System;
using Templ4te.V1.Data.Context;
using Templ4te.V1.Domain.Interfaces;
using Templ4te.V1.Domain.Usuarios;

namespace Templ4te.V1.Data
{
    public class TelefoneRepository : RepositoryBase<Telefone>, IUsuarioRepository
    {
        public TelefoneRepository(ContextEFC contextEFC)
            : base(contextEFC)
        {

        }
    }
}
