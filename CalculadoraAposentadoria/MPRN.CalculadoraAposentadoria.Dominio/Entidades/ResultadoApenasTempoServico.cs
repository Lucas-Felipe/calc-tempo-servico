using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Entidades
{
    public class ResultadoApenasTempoServico: ResultadoVerificacaoTempoIntegral
    {
        public int NovoLimiteIdade { get; set; }
        public ResultadoApenasTempoServico(Pessoa pessoa, int contribuicaoTotal,int novoLimiteIdade) : base(pessoa,contribuicaoTotal)
        {
            
            NovoLimiteIdade = novoLimiteIdade;
            
        }
        public override void Mensagem()
        {
            Console.WriteLine($"\nIdade: {Idade} anos\n" +
            $"Tempo de contribuição total: {ContribuicaoTotal} anos\n" +
            $"A regra da aposentadoria integral para {Genero} é:\n" +
            $"- Ter idade maior ou igual a {LimiteIdade} anos.\n" +
            $"- Tempo de contribuição maior ou igual a {LimiteTempoServico} anos.\n" +
            $"No seu caso, você não atende o requisito da idade, mas atende o requisito do tempo de " +
            $"contribuição. Descontando o seu tempo de contribuição a mais no limite do requisito da idade " +
            $"(fincando o novo limite de {NovoLimiteIdade} anos)" +
            $" você {(Idade>=NovoLimiteIdade? "" :"não ")}fica apto a se aposentar integralmente.");
        }

    }
}

