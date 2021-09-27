using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Entidades
{
    class ResultadoNaoApto:ResultadoVerificacaoTempoIntegral
    {
        public ResultadoNaoApto(Pessoa pessoa,int contribuicaoTotal):base(pessoa,contribuicaoTotal)
        {

        }

        public override void Mensagem()
        {

            Console.WriteLine($"\nIdade: {Idade} anos.\n" +
            $"Tempo de contribuição total: {ContribuicaoTotal } anos.\n" +
            $"A regra da aposentadoria integral para {Genero} é:\n" +
            $"- Ter idade maior ou igual a {LimiteIdade} anos.\n" +
            $"- Tempo de contribuição maior ou igual a {LimiteTempoServico} anos.\n"+
            $"Você não está apto a se aposentar.");
        }
    }
}
