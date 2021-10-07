using DTOs;
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
            
            try
            {
                
                var resultadoabono = calculotemposervico.CalcularAbono();
                
                var resultadointegral = calculotemposervico.VerificarTempoIntegral();

                var pessoa = calculotemposervico.Pessoa;

                var resultadoCalculoDTO = new ResultadoCalculoDTO {
                    Pessoa = pessoa,
                    ResultadoCalculoAbono=resultadoabono,
                    ResultadoVerificacaoTempoIntegral=resultadointegral,
                };

                return Ok(resultadoCalculoDTO);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
       
    }
}
