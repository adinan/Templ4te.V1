using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Templ4te.V1.Domain.Usuarios
{
    public class Telefone : EntityBase<Telefone>
    {
        public int Prefixo { get; private set; }
        public string Fixo { get; private set; }
        public string Movel { get; private set; }

        public override bool EstaValido()
        {
            throw new NotImplementedException();
        }

        // EF propriedades de navegacao
        public Usuario Usuario { get; set; }


        private void ValidarPrefixo()
        {
            RuleFor(c => c.Fixo)
                .NotEmpty().WithMessage("O número DDD precisa ser fornecido")
                .Length(2).WithMessage("O DDD deve conter 2 caracteres");
        }

        private void ValidarNumeroFixo()
        {
            RuleFor(c => c.Fixo)
                .NotEmpty().WithMessage("O número precisa ser fornecido")
                .Length(8).WithMessage("O número precisa 8 caracteres");
        }

        private void ValidarNumeroMovel()
        {
            RuleFor(c => c.Fixo)
                .NotEmpty().WithMessage("O número precisa ser fornecido")
                .Length(9).WithMessage("O número precisa 9 caracteres");
        }
    }

    public static class TelefoneExtension
    {
        public static bool EstaoValidos(this ICollection<Telefone> telefones)
        {
            foreach (var telefone in telefones)
            {
                telefone.EstaValido();
            }
            if (telefones.Any(p => p.EstaValido())) return false;

            return true;
        }

    }
}
