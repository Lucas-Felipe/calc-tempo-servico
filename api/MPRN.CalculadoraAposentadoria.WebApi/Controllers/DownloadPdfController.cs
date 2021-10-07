using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
using MPRN.CalculadoraAposentadoria.Dominio.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DownloadPdfController:Controller
    {
        [HttpGet]
        public IActionResult Pdf()
        {
            return Ok();
        }
    }
}
