using DTOs;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using MPRN.CalculadoraAposentadoria.Dominio.Entidades;
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
        public MemoryStream PDFBase(ResultadoCalculoDTO DTO)
        {
            MemoryStream ms = new MemoryStream();

            PdfWriter pw = new PdfWriter(ms);

            PdfDocument PdfDocument = new PdfDocument(pw);


            Document doc = new Document(PdfDocument, PageSize.A4);

            var path = Directory.GetCurrentDirectory();

            Image img = new Image(ImageDataFactory.Create($"{path}/../../front/src/assets/mprn-mid.png"));
            img.SetWidth(UnitValue.CreatePercentValue(60));
            img.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            doc.Add(img);
            doc.Add(new Paragraph(DTO.Pessoa.Genero.ToString()));

            doc.Close();

            return ms;
        }

        public MemoryStream GeraPdf(MemoryStream ms)
        {
            byte[] byteStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(byteStream, 0, byteStream.Length);
            ms.Position = 0;
            return ms;
        }

    }
}
