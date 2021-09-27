using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Entidades
{
    public class ResultadoVerificacaoTempoIntegral
    {
        public int Idade { get; private set; }
        public GeneroEnum Genero {get;private set;}
        public int ContribuicaoTotal { get; private set; }
        public int LimiteIdade { get; private set; }
        public int LimiteTempoServico { get; private set; }

        public ResultadoVerificacaoTempoIntegral(Pessoa pessoa, int contribuicaoTotal)
        {
            LimiteIdade = pessoa.Masculino() ? CalculoTempoServico.limiteIdadeHomem : CalculoTempoServico.limiteIdadeMulher;
            LimiteTempoServico = pessoa.Masculino() ? CalculoTempoServico.limiteServicoAnosHomem : CalculoTempoServico.limiteServicoAnosMulher;

            ContribuicaoTotal = contribuicaoTotal;
            Idade = pessoa.Idade();
            Genero = pessoa.Genero;
            
        }

        public virtual void Mensagem()
        {
            Console.WriteLine($"\nIdade: {Idade} anos\n" +
                $"Tempo de contribuição total: {ContribuicaoTotal } anos\n" +
                $"A regra da aposentadoria integral para {Genero} é:\n" +
                $"- Ter idade maior ou igual a {LimiteIdade} anos.\n" +
                $"- Tempo de contribuição maior ou igual a {LimiteTempoServico} anos.\n" +
                $" Você está apto a se aposentar integralmente.");
        }
    }
}
