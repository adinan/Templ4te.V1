using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Templ4te.V1.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntityBase<TEntity>
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
