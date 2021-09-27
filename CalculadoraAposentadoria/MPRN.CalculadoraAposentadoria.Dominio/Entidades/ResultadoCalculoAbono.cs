using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Entidades
{
    public class ResultadoCalculoAbono
    {
        public int FrequenciaTotal { get; private set; }
        public int AverbacaoTotal { get; private set; }
        public int TempoFicto { get; private set; }
        public int LicencaPremio { get; private set; }
        public int TempoAverbadoTotal { get; private set; }
        public int TempoRestante { get; private set; }
        public int Pedagio { get; private set; }
        public int TempoParaAbono { get; private set; }
        public int TempoTotalContribuicao { get; private set; }
        public int TempoGeralServico { get; private set; }
        public string DataInicioAbono { get; private set; }

        public ResultadoCalculoAbono(int frequenciaTotal, int averbacaoTotal, int tempoFicto, int licencaPremio, 
            int tempoAverbadoTotal, int tempoRestante, int pedagio, int tempoParaAbono, int tempoTotalContribuicao,
            int tempoGeralServico, string dataInicioAbono)
        {
            FrequenciaTotal = frequenciaTotal;
            AverbacaoTotal = averbacaoTotal;
            TempoFicto = tempoFicto;
            LicencaPremio = licencaPremio;
            TempoAverbadoTotal = tempoAverbadoTotal;
            TempoRestante = tempoRestante;
            Pedagio = pedagio;
            TempoParaAbono = tempoParaAbono;
            TempoTotalContribuicao = tempoTotalContribuicao;
            TempoGeralServico = tempoGeralServico;
            DataInicioAbono = dataInicioAbono;

            
        }

        public void Mensagem()
        {
            Console.WriteLine($"\nTempo de contribuição em dias: {FrequenciaTotal}\n" +
            $"Tempo de contribuição em dias averbado com  MPRN: {AverbacaoTotal}\n" +
            $"Tempo Ficto: {TempoFicto}\n" +
            $"Liçença-prêmio em dias não usufruído: {LicencaPremio}\n" +
            $"Tempo de contribuição averbado total: {TempoAverbadoTotal}\n" +
            $"Tempo restante a partir de 17/12/1998: {TempoRestante}\n" +
            $"Pedágio: {Pedagio}\n" +
            $"Tempo restante para abono de permanência: {TempoParaAbono}\n" +
            $"Tempo total de contribuição para abono de permanência: {TempoTotalContribuicao}\n" +
            $"Total geral de tempo de serviço: {TempoGeralServico} anos\n" +
            $"Data de início para abono de permanência: {DataInicioAbono}");
        }

    }
}
