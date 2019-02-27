namespace Templ4te.V1.Domain.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : EntityBase<TEntity>
    {        
        int Commit();
        void Dispose();
    }
}