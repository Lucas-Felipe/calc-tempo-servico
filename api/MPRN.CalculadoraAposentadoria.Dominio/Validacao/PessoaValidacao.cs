using FluentValidation;
using MPRN.CalculadoraAposentadoria.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Validacao
{
    public class PessoaValidacao:AbstractValidator<Pessoa>
    {
        public PessoaValidacao()
        {
            RuleFor(p => p.DataNascimento)
                .NotEmpty().WithMessage("Campo data de nascimento não pode ser vazio!");

            RuleFor(m => m.Genero)
                .IsInEnum().WithMessage("Gênero não encontrado!")
                .NotNull().WithMessage("Campo de gênero não pode ser nulo!");
                
        }

    }
}
