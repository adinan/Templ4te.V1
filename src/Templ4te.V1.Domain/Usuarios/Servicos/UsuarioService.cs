using System;
using Templ4te.V1.Domain.Interfaces;
using Templ4te.V1.Domain.Usuarios.Interfaces;

namespace Templ4te.V1.Domain.Usuarios.Servicos
{
    public sealed class UsuarioServico : ServiceBase<Usuario>, IUsuarioService
    {
        public IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioServico(IUsuarioRepository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            _usuarioRepository = repository;
        }

        public override void Adicionar(Usuario usuario)
        {
            if (!UsuarioValido(usuario)) return;

            //Validações de Banco
            validarCpfJaEmUso(usuario);

            Adicionar(usuario);
            Commit();
        }

        public override void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public override void Remover(int id)
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

            return false;
        }

        private void validarCpfJaEmUso(Usuario usuario)
        {
            var usuarioBanco = _usuarioRepository.ObterPorCpf(usuario.Cpf);

            if(usuarioBanco != null)

        }
    }
}
