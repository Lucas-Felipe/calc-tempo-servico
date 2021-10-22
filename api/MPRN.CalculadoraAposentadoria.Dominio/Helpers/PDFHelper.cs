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

            doc.Add(LogoMP());

            doc.Add(HeaderMPInfo());

             //doc.Add(new Paragraph("Certidão de tempo de contribuição"));

            doc.Add(new Paragraph("\r\n"));

            doc.Add(new Paragraph("Dados Pessoais:").SetBold());
            
            doc.Add(CriaDadosPessoais(DTO));

            doc.Add(new Paragraph("\r\n"));

            doc.Add(CriaResultadoIntegral(DTO));
            
            doc.Add(new Paragraph("\r\n"));

            doc.Add(CriaResultadoAbono(DTO));
           
            doc.Close();

            return ms;
        }

        private Text CriaTexto(string text){
            Text texto=new Text(text);
            return texto;
        }

        private Cell createTextCell(String text)
        {
            Cell cell = new Cell();
            Paragraph p = new Paragraph(text);
            p.SetTextAlignment(TextAlignment.RIGHT);
            cell.Add(p).SetVerticalAlignment(VerticalAlignment.BOTTOM);
            cell.SetBorder(Border.NO_BORDER);
            return cell;
        }

        private Image LogoMP()
        {
            var path = Directory.GetCurrentDirectory();

            Image img = new Image(ImageDataFactory.Create($"{path}/../src/fonts/mprn-mid.png"));
            img.SetWidth(UnitValue.CreatePercentValue(50));
            img.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            return img;
        }

        private Paragraph HeaderMPInfo()
        {
           return new Paragraph(CriaTexto("Procuradoria-Geral de Justiça do Estado do Rio Grande do Norte\r\n".ToUpper()).SetBold()).SetTextAlignment(TextAlignment.CENTER)
                .Add(CriaTexto("CNPJ Nº 08.539.710/0001-04\r\n")).SetTextAlignment(TextAlignment.CENTER)
                .Add(CriaTexto("Rua Promotor Manoel Alves Pessoa Neto, 97 - Candelária - Natal/RN - CEP: 59065-555")).SetTextAlignment(TextAlignment.CENTER);
        }
        private Table CriaDadosPessoais(ResultadoCalculoDTO DTO)
        {
            
            Table tabeladados = new Table(5, false);
            Cell cell1 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT);
            Paragraph p = new Paragraph(new Text("Gênero: ").SetBold());
            Text t = new Text(DTO.Pessoa.Genero.ToString());
            p.Add(t);
            cell1.Add(p);
            Cell cell2 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(new Text("Data de nascimento: ").SetBold()).Add(new Text(DTO.Pessoa.DataNascimento.ToString("dd/MM/yyyy"))));
            Cell cell3 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(new Text("Idade: ").SetBold()).Add(new Text((DTO.Pessoa.Idade/365).ToString()+" anos")));
            tabeladados.AddCell(cell1);
            tabeladados.AddCell(cell2);
            tabeladados.AddCell(cell3);

            return tabeladados;
        }
        private Paragraph CriaResultadoIntegral(ResultadoCalculoDTO DTO)
        {
            Paragraph p = new Paragraph();

            p.Add(new Paragraph("Resultado da verificação de aposentadoria em tempo integral").SetBold())
            .Add(new Text($"\r\nTempo de contribuição total: {DTO.ResultadoApenasTempoServico.ContribuicaoTotal} dias\r\n"))
            .Add(new Text($"Limite de idade para {DTO.Pessoa.Genero}: {DTO.ResultadoApenasTempoServico.LimiteIdade}\r\n"))
            .Add(new Text($"Limite de tempo de serviço para {DTO.Pessoa.Genero}: {DTO.ResultadoApenasTempoServico.LimiteTempoServico}\r\n"))
            .Add(DTO.ResultadoApenasTempoServico.NovoLimiteIdade<DTO.ResultadoApenasTempoServico.LimiteIdade? new Text($"Novo Limite de idade com desconto de tempo de trabalho a mais: {DTO.ResultadoApenasTempoServico.NovoLimiteIdade}\r\n") : new Text("\r\n"))
            .Add((DTO.ResultadoApenasTempoServico.ContribuicaoTotal>DTO.ResultadoApenasTempoServico.LimiteTempoServico
            && DTO.Pessoa.Idade>DTO.ResultadoApenasTempoServico.LimiteIdade? new Text($"Você está apto(a) a se aposentar.") : 
            (DTO.ResultadoApenasTempoServico.ContribuicaoTotal>DTO.ResultadoApenasTempoServico.LimiteTempoServico
            && DTO.Pessoa.Idade<DTO.ResultadoApenasTempoServico.LimiteIdade? (DTO.Pessoa.Idade>DTO.ResultadoApenasTempoServico.NovoLimiteIdade?
            new Text($"Você está apto(a) a se aposentar."): new Text($"Você NÃO está apto(a) a se aposentar.")):new Text($"Você NÃO está apto(a) a se aposentar."))));
            return p;
        }

        private Paragraph CriaResultadoAbono(ResultadoCalculoDTO DTO)
        {
            Paragraph p = new Paragraph();
            if (DTO.ResultadoCalculoAbono.Mensagem != null)
            {
                p.Add(new Paragraph("Aviso! O cálculo do abono de permanência não é feito para mulheres!"));
            }
            else 
            {
                p.Add(new Paragraph("Resultado do cálculo do abono de permanência").SetBold())
                .Add(new Text($"\r\nFrequência total: {DTO.ResultadoCalculoAbono.FrequenciaTotal} dias\r\n"))
                .Add(new Text($"Tempo de contribuição até 16/12/1998 (averbado): {DTO.ResultadoCalculoAbono.AverbacaoTotal} dias\r\n"))
                .Add(new Text($"Tempo ficto: {DTO.ResultadoCalculoAbono.TempoFicto} dias\r\n"))
                .Add(new Text($"Licença-Prêmio: {DTO.ResultadoCalculoAbono.LicencaPremio} dias\r\n"))
                .Add(new Text($"Tempo averbado total: {DTO.ResultadoCalculoAbono.TempoAverbadoTotal} dias\r\n"))
                .Add(new Text($"Tempo restante a partir de 17/12/1998: {DTO.ResultadoCalculoAbono.TempoRestante} dias\r\n"))
                .Add(new Text($"Pedágio: {DTO.ResultadoCalculoAbono.Pedagio} dias\r\n"))
                .Add(new Text($"Tempo restante para abono de permanência: {DTO.ResultadoCalculoAbono.TempoParaAbono} dias\r\n"))
                .Add(new Text($"Tempo total de contribuição para abono de permanência: {DTO.ResultadoCalculoAbono.TempoTotalContribuicao} dias\r\n"))
                .Add(new Text($"Data de início do abono: {DTO.ResultadoCalculoAbono.DataInicioAbono}"));
            }
            return p;
        }

        public byte[] GeraPdf(MemoryStream ms)
        {
            byte[] byteStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(byteStream, 0, byteStream.Length);
            ms.Position = 0;
            return ms.ToArray();
        }

        public void geradocumento(ResultadoCalculoDTO DTO)
        {
            var arquivo = @"../../../documento.pdf";

            using (PdfWriter pwriter=new PdfWriter(arquivo, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDocument=new PdfDocument(pwriter);

                var doc=new Document(pdfDocument,PageSize.A4);
                doc.Add(LogoMP());

                doc.Add(HeaderMPInfo());

                //doc.Add(new Paragraph("Certidão de tempo de contribuição"));

                doc.Add(new Paragraph("\r\n"));

                doc.Add(new Paragraph("Dados Pessoais:").SetBold());
                
                doc.Add(CriaDadosPessoais(DTO));

                doc.Add(new Paragraph("\r\n"));

                doc.Add(CriaResultadoIntegral(DTO));
                
                doc.Add(new Paragraph("\r\n"));

                doc.Add(CriaResultadoAbono(DTO));
            
                doc.Close();
                doc.Close();
                pdfDocument.Close();
            }
            
        }
    }
}
