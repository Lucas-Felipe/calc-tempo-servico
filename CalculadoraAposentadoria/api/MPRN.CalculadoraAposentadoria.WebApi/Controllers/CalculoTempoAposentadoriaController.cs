using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MPRN.CalculadoraAposentadoria.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculoTempoAposentadoriaController:ControllerBase
    {
        [HttpPost]
        public IActionResult CalcularTempoParaExibir([FromBody]CalculoTempoServico calculotemposervico)
        {
            List<object> lista = new List<object>();

           
            try
            {
                var resultadoabono = calculotemposervico.CalcularAbono();
                lista.Add(resultadoabono);
            }
            catch (Exception e)
            {

                lista.Add(e.Message);
            }

            try
            {
                var resultadointegral = calculotemposervico.VerificarTempoIntegral();
                lista.Add(resultadointegral);

            }
            catch (Exception e)
            {

                lista.Add(e.Message);
            }

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }

            return Ok(lista);
        }

        

    }
}
