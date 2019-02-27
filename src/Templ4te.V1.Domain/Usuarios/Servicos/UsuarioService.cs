using System;
using Templ4te.V1.Domain.Interfaces;
using Templ4te.V1.Domain.Usuarios.Interfaces;

namespace Templ4te.V1.Domain.Usuarios.Servicos
{
    public class UsuarioServico : ServiceBase<Usuario>, IUsuarioService
    {
        public UsuarioServico(IUsuarioRepository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }

        public override void Adicionar(Usuario usuario)
        {
            if (!UsuarioValido(usuario)) return;

            Adicionar(usuario);
            Commit();
        }

        public override void Atualizar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public override void Remover(int id)
        {
            throw new NotImplementedException();
        }

        private bool UsuarioValido(Usuario usuario)
        {
            if (usuario.EstaValido()) return true;

            //NotificarValidacoesErro(evento.ValidationResult);
            return false;
        }
    }
}
