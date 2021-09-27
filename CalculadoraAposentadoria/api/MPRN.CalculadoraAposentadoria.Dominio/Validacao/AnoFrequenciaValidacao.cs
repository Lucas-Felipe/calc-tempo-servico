using FluentValidation;
using MPRN.CalculadoraAposentadoria.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Validacao
{
    public class AnoFrequenciaValidacao:AbstractValidator<AnoFrequencia>
    {
        public AnoFrequenciaValidacao()
        {

            RuleFor(p => p.Ano)
                .NotEmpty().WithMessage("Campo do ano não pode ser vazio!")
                .GreaterThanOrEqualTo(1900).WithMessage("Campo de ano não pode ser menor ou igual 1900!");

            RuleFor(p => p.TempoLiquido)
                .NotEmpty().WithMessage("Campo de tempo líquido não pode ser vazio!")
                .GreaterThanOrEqualTo(0).WithMessage("Campo de tempo líquido não pode ser menor do que zero!");
            
        }
        
    }
}
