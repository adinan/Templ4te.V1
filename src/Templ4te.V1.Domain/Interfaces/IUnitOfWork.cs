using System;

namespace Templ4te.V1.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
