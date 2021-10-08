using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace MPRN.CalculadoraAposentadoria.Dominio.Entidades
{
    public class CalculoTempoServico
    {
        public const int limiteServicoAnosHomem = 12775;
        public const int limiteServicoAnosMulher = 10950;
        public const int limiteIdadeHomem = 21915;
        public const int limiteIdadeMulher = 20089;

        public Pessoa Pessoa { get; set; }

        public IList<AnoFrequencia> Frequencias { get; set; }

        public int Averbacoes { get; set; }

        public int LicencaPremioEmDias { get; set; }

        public CalculoTempoServico(Pessoa pessoa, int? averbado= null, int ? licenca = null)
        {
            Pessoa = pessoa;
            Frequencias = new List<AnoFrequencia>();
            Averbacoes = averbado.GetValueOrDefault();
            LicencaPremioEmDias = licenca.GetValueOrDefault();
        }
        public CalculoTempoServico()
        {

        }
        public ResultadoVerificacaoTempoIntegral VerificarTempoIntegral()
        {
            if (PossuiTempodeServicoIdade())
            {
               
                return new ResultadoVerificacaoTempoIntegral(Pessoa,CalcularTempoGeralServico());
            }
            if (PossuiApenasTempoServico())
            {
               
                return new ResultadoApenasTempoServico(Pessoa, CalcularTempoGeralServico(),NovoLimitedeIdade());
            }

            // throw new Exception("Você não está apto a se aposentar.");
            return new ResultadoVerificacaoTempoIntegral(Pessoa, CalcularTempoGeralServico());
            
        }

        private bool PossuiTempodeServicoIdade()
        {
            if (Pessoa.Masculino())
            {
                return (Pessoa.Idade >= limiteIdadeHomem) && (CalcularTempoGeralServico() >= limiteServicoAnosHomem);
            }
            return (Pessoa.Idade >= limiteIdadeMulher) && (CalcularTempoGeralServico() >= limiteServicoAnosMulher);
            
        }

        private bool PossuiApenasTempoServico()
        {
            if (Pessoa.Masculino())
            {
                return (Pessoa.Idade < limiteIdadeHomem) && (CalcularTempoGeralServico() >= limiteServicoAnosHomem);
            }
            return (Pessoa.Idade < limiteIdadeMulher) && (CalcularTempoGeralServico() >= limiteServicoAnosMulher);
        }

        private int NovoLimitedeIdade()
        {
            if (Pessoa.Masculino())
            {
                return limiteIdadeHomem - (CalcularTempoGeralServico() - limiteServicoAnosHomem);
            }
            return limiteIdadeMulher - (CalcularTempoGeralServico() - limiteServicoAnosMulher);
        }

        public ResultadoCalculoAbono CalcularAbono()
        {
            if (Pessoa.Masculino())
            {
                return new ResultadoCalculoAbono(frequenciaTotal:CalcularFrequenciaTotal(),averbacaoTotal:Averbacoes,
                    tempoFicto:CalcularTempoFicto(),licencaPremio:LicencaPremioEmDias,tempoAverbadoTotal:CalcularAverbadoTotal(),
                    tempoRestante:CalcularTempoRestante(),pedagio:CalcularPedagio(),tempoParaAbono:CalcularTempoParaAbono(),
                    tempoTotalContribuicao:CalcularTempoTotaldeContribuicao(),/*tempoGeralServico:CalcularTempoGeralServico(),*/
                    dataInicioAbono:CalcularDataInicio());
            }

            //throw new Exception("Aviso! O cálculo do abono permanência não é feito para mulheres.");
            return new ResultadoCalculoAbono("Aviso! O cálculo do abono permanência não é feito para mulheres.");
        }

        private string CalcularDataInicio()
        {
            return new DateTime(1998,12,17).AddDays(CalcularTempoParaAbono()+15).ToString("dd/MM/yyyy");
        }

        private int CalcularTempoGeralServico()
        {
            return CalcularFrequenciaTotal() + CalcularAverbadoTotal();
        }
        
        private int CalcularTempoTotaldeContribuicao()
        {
            return CalcularPedagio() + CalcularFrequenciaTotal();
        }

        private int CalcularTempoParaAbono()
        {
            return CalcularPedagio() + CalcularTempoRestante();
        }

        private int CalcularPedagio()
        {
            return (int)(CalcularTempoRestante() * 0.20);
        }

        private int CalcularTempoRestante()
        {
            return CalcularFrequenciaTotal()-CalcularAverbadoTotal();
        }

        private int CalcularAverbadoTotal()
        {
            return CalcularTempoFicto()+Averbacoes+LicencaPremioEmDias;
        }

        private int CalcularFrequenciaTotal()
        {
            return Frequencias.Sum(p => p.TempoLiquido);
        }

        //private int CalcularAverbacaoTotal()
        //{
        //    return Averbacoes.Sum(p => p.QuantidadeDias);
        //}

        private int CalcularTempoFicto()
        {
            return (int)((Averbacoes + CalculaSomatorioFrequenciasAte1998()-15) * 0.17);
        }

        private int CalculaSomatorioFrequenciasAte1998()
        {
            return Pessoa.Genero==GeneroEnum.HOMEM ? Frequencias.Where(w => w.Ano <= 1998).Sum(w => w.TempoLiquido) : 0;
        }
    }
}
