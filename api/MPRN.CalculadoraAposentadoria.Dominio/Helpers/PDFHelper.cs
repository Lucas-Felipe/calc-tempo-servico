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
            img.SetWidth(UnitValue.CreatePercentValue(50));
            img.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            doc.Add(img);
            doc.Add(CriaParagrafo("Procuradoria-Geral de Justiça do Estado do Rio Grande do Norte".ToUpper()));
            doc.Add(CriaParagrafo("CNPJ Nº 08.539.710/0001-04"));
            doc.Add(CriaParagrafo("Rua Promotor Manoel Alves Pessoa Neto, 97 - Candelária - Natal/RN - CEP: 59065-555"));
            doc.Add(new Paragraph("\r\n"));

            doc.Add(new Paragraph("Dados Pessoais:"));
            Table tabeladados = new Table(5, false);
            Cell cell1 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT);
            Paragraph p = new Paragraph("Gênero: ").SetBold();
            Text t = new Text(DTO.Pessoa.Genero.ToString());
            p.Add(t);
            cell1.Add(p);
            Cell cell2 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Data de nascimento: ").SetBold().Add(new Text(DTO.Pessoa.DataNascimento.ToString("dd/MM/yyyy"))));
            Cell cell3 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Idade: ").SetBold().Add(new Text((DTO.Pessoa.Idade/365).ToString()+" anos")));
            tabeladados.AddCell(cell1);
            tabeladados.AddCell(cell2);
            tabeladados.AddCell(cell3);
            doc.Add(tabeladados);
            doc.Add(new Paragraph("\r\n"));

            doc.Add(new Paragraph("Resultado da verificação de aposentadoria em tempo integral").SetBold());
            doc.Add(new Paragraph($"Tempo de contribuição total: {DTO.ResultadoVerificacaoTempoIntegral.ContribuicaoTotal/365} anos"));
            doc.Add(new Paragraph($"Limite de idade para {DTO.Pessoa.Genero}: {DTO.ResultadoVerificacaoTempoIntegral.LimiteIdade}"));
            doc.Add(new Paragraph($"Limite de tempo de serviço para {DTO.Pessoa.Genero}: {DTO.ResultadoVerificacaoTempoIntegral.LimiteTempoServico}"));
            //if (DTO.ResultadoApenasTempoServico.NovoLimiteIdade != null)
            //    doc.Add(new Paragraph($"Novo limite de idade devido tempo de contribuição a mais: {DTO.ResultadoApenasTempoServico.NovoLimiteIdade}"));
            //else 
            //    doc.Add(new Paragraph($"Novo limite de idade devido tempo de contribuição a mais: N/A"));
           
            doc.Add(new Paragraph("\r\n"));

            if (DTO.ResultadoCalculoAbono.Mensagem != null)
            {
                doc.Add(new Paragraph("Aviso! O cálculo do abono de permanência não é feito para mulheres!"));
            }
            else 
            {
                doc.Add(new Paragraph("Resultado do cálculo do abono de permanência:").SetBold());
                doc.Add(new Paragraph($"Frequência total:{DTO.ResultadoCalculoAbono.FrequenciaTotal}"));
                doc.Add(new Paragraph($"Tempo de contribuição até 16/12/1998 (averbado): {DTO.ResultadoCalculoAbono.AverbacaoTotal}"));
                doc.Add(new Paragraph($"Tempo ficto: {DTO.ResultadoCalculoAbono.TempoFicto}"));
                doc.Add(new Paragraph($"Licença-Prêmio:{DTO.ResultadoCalculoAbono.LicencaPremio}"));
                doc.Add(new Paragraph($"Tempo averbado total: {DTO.ResultadoCalculoAbono.TempoAverbadoTotal}"));
                doc.Add(new Paragraph($"Tempo restante a partir de 17/12/1998: {DTO.ResultadoCalculoAbono.TempoRestante}"));
                doc.Add(new Paragraph($"Pedágio: {DTO.ResultadoCalculoAbono.Pedagio}"));
                doc.Add(new Paragraph($"Tempo restante para abono de permanência: {DTO.ResultadoCalculoAbono.TempoParaAbono}"));
                doc.Add(new Paragraph($"Tempo total de contribuição para abono de permanência: {DTO.ResultadoCalculoAbono.TempoTotalContribuicao}"));
                doc.Add(new Paragraph($"Data de início do abono: {DTO.ResultadoCalculoAbono.DataInicioAbono}"));
            }
            //doc.Add(new Paragraph("Certidão de tempo de contribuição"));
            doc.Close();

            return ms;
        }

        private Paragraph CriaParagrafo(string text){
            Paragraph paragrafo=new Paragraph(text);
            paragrafo.SetTextAlignment(TextAlignment.CENTER);
            paragrafo.SetBold();
            return paragrafo;
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
