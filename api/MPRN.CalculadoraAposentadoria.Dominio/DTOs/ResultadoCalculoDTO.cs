using MPRN.CalculadoraAposentadoria.Dominio.Entidades;

namespace DTOs
{
    public class ResultadoCalculoDTO
    {
        public Pessoa Pessoa {get;set;}
        public ResultadoCalculoAbono ResultadoCalculoAbono {get;set;}
        public ResultadoVerificacaoTempoIntegral ResultadoVerificacaoTempoIntegral {get;set;}
    }
}