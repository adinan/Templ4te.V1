using FluentValidation;
using System;
using System.Collections.Generic;
using Templ4te.V1.Infra.CrossCutting.Common;

namespace Templ4te.V1.Domain.Usuarios
{
    public class Usuario : EntityBase<Usuario>
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }

        // EF propriedades de navegacao
        public virtual Endereco Endereco { get; private set; }
        public virtual ICollection<Telefone> Telefones { get; private set; }

        // Construtor para o EF
        protected Usuario() { }

        public Usuario(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf.RemoveMask();
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


        #region Validations

        public override bool EstaValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }


        private void Validar()
        {
            ValidarEndereco();
            ValidarNome();
            ValidarCpf();
            ValidationResult = Validate(this);
        }

        private void ValidarEndereco()
        {
            RuleFor(c => c.Endereco)
               .NotEmpty().WithMessage("É preciso cadastrar um endereço.");

            if (Endereco == null || Endereco.EstaValido()) return;

            foreach (var error in Endereco.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do evento precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome do evento precisa ter entre 2 e 150 caracteres");
        }

        private void ValidarCpf()
        {
            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O Cpf precisa ser fornecido")
                .Must(ValidaCpf).WithMessage("Cpf no formato invalido");
        }

        private bool ValidaCpf(string cpf)
        {
            if (cpf.Length > 11)
                return false;
            while (cpf.Length != 11)
                cpf = '0' + cpf;
            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;
            if (igual || cpf == "12345678909")
                return false;
            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];
            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];
            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
            if (numeros[10] != 11 - resultado)
                return false;
            return true;
        }

        #endregion
    }
}
