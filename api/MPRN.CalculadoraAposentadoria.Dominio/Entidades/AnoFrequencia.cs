using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Entidades
{
    public class AnoFrequencia
    {
        
        public int Ano { get;  set; }

        public int TempoLiquido { get;  set; }

        public AnoFrequencia(int ano,int tempoliquido)
        {
            Ano = ano;
            TempoLiquido = tempoliquido;
        }
    }
}
