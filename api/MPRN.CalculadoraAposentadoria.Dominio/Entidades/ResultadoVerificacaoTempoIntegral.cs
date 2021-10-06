using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Entidades
{
    public class ResultadoVerificacaoTempoIntegral
    {
        //public int Idade { get; private set; }
        //public GeneroEnum Genero {get; private set;}
        public int ContribuicaoTotal { get; private set; }
        public int LimiteIdade { get; private set; }
        public int LimiteTempoServico { get; private set; }

        public ResultadoVerificacaoTempoIntegral(Pessoa pessoa, int contribuicaoTotal)
        {
            LimiteIdade = pessoa.Masculino() ? CalculoTempoServico.limiteIdadeHomem : CalculoTempoServico.limiteIdadeMulher;
            LimiteTempoServico = pessoa.Masculino() ? CalculoTempoServico.limiteServicoAnosHomem : CalculoTempoServico.limiteServicoAnosMulher;

            ContribuicaoTotal = contribuicaoTotal;
            //Idade = pessoa.Idade;
            //Genero = pessoa.Genero;
        }
    }
}
