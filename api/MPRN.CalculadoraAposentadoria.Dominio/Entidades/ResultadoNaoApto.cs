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

       
    }
}
