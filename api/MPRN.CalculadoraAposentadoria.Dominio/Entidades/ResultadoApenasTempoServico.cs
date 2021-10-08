using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Entidades
{
    public class ResultadoApenasTempoServico: ResultadoVerificacaoTempoIntegral
    {
        public int NovoLimiteIdade { get; private set; }
        public ResultadoApenasTempoServico(Pessoa pessoa, int contribuicaoTotal,int novoLimiteIdade) : base(pessoa,contribuicaoTotal)
        {
            
            NovoLimiteIdade = novoLimiteIdade;
            
        }
        

    }
}

