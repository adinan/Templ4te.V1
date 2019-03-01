using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using Templ4te.V1.Domain.Interfaces;

namespace Templ4te.V1.Domain
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : EntityBase<TEntity>
    {
        protected readonly IRepositoryBase<TEntity> _repositorio;
        protected readonly IUnitOfWork _unitOfWork;
        public Dictionary <string,string> _notifications { get; protected set; }

        public ServiceBase(IRepositoryBase<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repositorio = repository;
            _unitOfWork = unitOfWork;
        }

        public abstract void Adicionar(TEntity entity);
        public abstract void Atualizar(TEntity entity);
        public abstract void Remover(int id);



        public void Dispose()
        {
            _repositorio.Dispose();
        }        

        public int Commit()
        {
            return _unitOfWork.Commit();
        }
    }
    public abstract class Teste
    {
        public abstract void MethodTeste();
    }

}
