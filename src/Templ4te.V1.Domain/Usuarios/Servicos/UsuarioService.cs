using System;
using Templ4te.V1.Domain.Interfaces;
using Templ4te.V1.Domain.Notifications;
using Templ4te.V1.Domain.Usuarios.Interfaces;

namespace Templ4te.V1.Domain.Usuarios.Servicos
{
    public sealed class UsuarioServico : ServiceBase<Usuario>, IUsuarioService
    {
        public IUsuarioRepository _usuarioRepository { get; set; }
        private readonly string sender = typeof(UsuarioServico).Name;


        public UsuarioServico(IUsuarioRepository repository, IUnitOfWork unitOfWork, IDomainNotificationList _notifications)
            : base(repository, unitOfWork, _notifications)
        {
            _usuarioRepository = repository;
        }

        public void Adicionar(Usuario usuario)
        {
            //Validações de regras de negócios
            UsuarioValido(usuario);

            //Validações de Banco
            validarCpfJaEmUso(usuario);



            _usuarioRepository.Adicionar(usuario);
            //Commit();
        }

        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            var usuario = _usuarioRepository.ObterPorId(id);

            if (usuario == null)
            {
                return;
            }

            _usuarioRepository.Remover(id);
            throw new NotImplementedException();
        }

        private bool UsuarioValido(Usuario usuario)
        {
            if (usuario.EstaValido()) return true;
            
            foreach (var error in usuario.ValidationResult.Errors)
            {
                Notifications.Add(error.ErrorMessage, error.ErrorCode, sender);
            }

            return false;
        }

        private void validarCpfJaEmUso(Usuario usuario)
        {
            var usuarioBanco = _usuarioRepository.ObterPorCpf(usuario.Cpf);
            
            if (usuarioBanco != null)
            {
                Notifications.Add("Cpf já cadastrado no banco de dados", sender);
            }
        }
    }
}
