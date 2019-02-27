using FluentValidation;
using System;
using System.Collections.Generic;

namespace Templ4te.V1.Domain.Usuarios
{
    public class Usuario : EntityBase<Usuario>
    {
        public string Nome { get; private set; }    

        // EF propriedades de navegacao
        public virtual Endereco Endereco { get; private set; }
        public virtual ICollection<Telefone> Telefones { get; private set; }

        // Construtor para o EF
        protected Usuario() { }

        public Usuario(string nome)
        {
            Nome = nome;
        }

        public override bool EstaValido()
        {
            throw new NotImplementedException();
        }

        
        public void AtribuirEndereco(Endereco endereco)
        {
            if (!endereco.EstaValido()) return;
            Endereco = endereco;
        }

        public void AtribuirTelefone(Telefone telefone)
        {
            if (!telefone.EstaValido()) return;
            Telefones.Add(telefone);
        }


        public void AtribuirTelefones(ICollection<Telefone> telefones)
        {
            if (!telefones.EstaoValidos()) return;
            Telefones = telefones;
        }



        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do evento precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome do evento precisa ter entre 2 e 150 caracteres");
        }
    }
}
