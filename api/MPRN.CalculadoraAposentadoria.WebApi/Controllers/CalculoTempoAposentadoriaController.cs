using DTOs;
using iText.Layout;
using Microsoft.AspNetCore.Mvc;
using MPRN.CalculadoraAposentadoria.Dominio.Entidades;
using MPRN.CalculadoraAposentadoria.Dominio.Helpers;
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
                    ResultadoApenasTempoServico=resultadointegral,
                    
                };
                PDFHelper doc = new PDFHelper();

                return new FileStreamResult(doc.GeraPdf(doc.PDFBase(resultadoCalculoDTO)), "application/pdf");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
       
    }
}
