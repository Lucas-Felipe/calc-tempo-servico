using FluentValidation;
using MPRN.CalculadoraAposentadoria.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Validacao
{
    public class CalculoTempoServicoValidacao:AbstractValidator<CalculoTempoServico>
    {
        public CalculoTempoServicoValidacao()
        {
            RuleForEach(p => p.Frequencias).SetValidator(new AnoFrequenciaValidacao());
             
            RuleFor(m => m.Pessoa).SetValidator(new PessoaValidacao());

            RuleFor(m => m.Pessoa)
              .NotEmpty().WithMessage("Informações de pessoa são obrigatórias!");

            RuleFor(p => p.Frequencias)
                .NotEmpty().WithMessage("Frequencias devem ser obrigatorias!");

           

            //RuleForEach(q => q.Averbacoes).SetValidator(new TempoAverbadoValidacao());

        }
    }
}
