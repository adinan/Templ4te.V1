using System;
using Templ4te.V1.Domain.Interfaces;
using Templ4te.V1.Domain.Notifications;

namespace Templ4te.V1.Domain
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : EntityBase<TEntity>
    {
        protected readonly IRepositoryBase<TEntity> _repositorio;
        protected readonly IUnitOfWork _unitOfWork;
        protected IDomainNotificationList Notifications;

        public string sende { get; set; }

        public ServiceBase(IRepositoryBase<TEntity> repository, IUnitOfWork unitOfWork, IDomainNotificationList _notifications) 
        {
            _repositorio = repository;
            _unitOfWork = unitOfWork;
            Notifications = _notifications;

            sende = typeof(ServiceBase<TEntity>).Name;
        }
        /*
        public abstract void Adicionar(TEntity entity);
        public abstract void Atualizar(TEntity entity);
        public abstract void Remover(int id);
        */
        ..

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public int Commit()
        {
            return _unitOfWork.Commit();
        }
    }
}
