using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Entidades
{
    public class Pessoa
    {
        
        public string Nome { get; private set; }

        
        public GeneroEnum Genero { get; set; }

        
        public DateTime DataNascimento { get; set; }

        
        public string Email { get; private set; }

        public Pessoa()
        {

        }

        public int Idade 
        {
            get
            {
                TimeSpan idade = DateTime.Now - DataNascimento;
                
                return idade.Days;
            }
        }
        //Refatorar método para idade

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
