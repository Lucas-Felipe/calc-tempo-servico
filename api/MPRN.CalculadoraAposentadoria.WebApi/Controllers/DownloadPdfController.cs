using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
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
            MemoryStream ms = new MemoryStream();

            PdfWriter pw = new PdfWriter(ms);
            PdfDocument PdfDocument = new PdfDocument(pw);

            Document doc = new Document(PdfDocument, PageSize.A4);

            doc.Add(new Paragraph("Hello!"));
            doc.Close();

            byte[] byteStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(byteStream, 0, byteStream.Length);
            ms.Position = 0;
            return new FileStreamResult(ms, "application/pdf");
        }
    }
}
