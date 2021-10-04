using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MPRN.CalculadoraAposentadoria.Dominio.Helpers
{
    class PDFHelper
    {
        public Document GeraDocumentoPadrao(MemoryStream memoryStream)
        {
            var doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, memoryStream);
            doc.Open();

            var pathLogo = Path.Combine(Directory.GetCurrentDirectory(), "assets", "mprn-mid.png");
            Image logo = Image.GetInstance(pathLogo);
            logo.Alignment = Element.ALIGN_CENTER;
            logo.ScalePercent(27);
            doc.Add(logo);

            return doc;

        }

    }
}
