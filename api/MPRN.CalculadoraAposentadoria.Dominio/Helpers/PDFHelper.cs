using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MPRN.CalculadoraAposentadoria.Dominio.Helpers
{
    public class PDFHelper
    {
        public static Document GeraDocumentoPadrao()
        {
            MemoryStream ms = new MemoryStream();

            PdfWriter pw = new PdfWriter(ms);
            PdfDocument PdfDocument = new PdfDocument(pw);

            Document doc = new Document(PdfDocument, PageSize.A4);

            doc.Add(new Paragraph("Hello!"));

            Image logomp = new Image(ImageDataFactory.Create("../../../front/src/assets/mprn-mid.png"));
            logomp.SetWidth(UnitValue.CreatePercentValue(100));

            doc.Add(logomp);
            doc.Close();

            return doc;

        }

    }
}
