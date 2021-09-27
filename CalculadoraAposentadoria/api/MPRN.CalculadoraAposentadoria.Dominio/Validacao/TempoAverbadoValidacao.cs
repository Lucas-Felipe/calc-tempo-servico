using FluentValidation;
using MPRN.CalculadoraAposentadoria.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Validacao
{
    public class TempoAverbadoValidacao:AbstractValidator<TempoAverbado>
    {
        public TempoAverbadoValidacao()
        {
            RuleFor(p => p.QuantidadeDias)
                .GreaterThan(0).WithMessage("Campo de quantidade de dias não pode ser menor do zero!");
        }
    }
}
