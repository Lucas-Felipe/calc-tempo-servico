using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Entidades
{
    public class Pessoa
    {
        public string Nome { get; set; }

        public GeneroEnum Genero { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public int Idade()
        {
            TimeSpan idade = DateTime.Now - DataNascimento;
            
            return idade.Days/365;
        }

        public bool Masculino()
        {
            return Genero == GeneroEnum.HOMEM;
        }

        public bool Feminino()
        {
            return !Masculino();
        }
    }
}
