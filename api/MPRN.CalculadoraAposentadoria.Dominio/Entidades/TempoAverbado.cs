using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Entidades
{
    public class TempoAverbado
    {
        
        public int QuantidadeDias { get; set; }

        public TempoAverbado(int quantidadedias)
        {
            QuantidadeDias = quantidadedias;
        }
    }
}
