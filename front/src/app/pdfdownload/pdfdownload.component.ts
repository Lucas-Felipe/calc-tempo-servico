import { ActivatedRoute } from '@angular/router';
import { PdfdownloadService } from './pdfdownload.service';
import { Component, OnInit } from '@angular/core';
import { ResultadoCalculoTempoServico } from '../models/resultado-calculo-tempo-servico';

@Component({
  selector: 'app-pdfdownload',
  templateUrl: './pdfdownload.component.html',
  styleUrls: ['./pdfdownload.component.scss']
})
export class PDFDownloadComponent implements OnInit {
  resultadoCalculo!: ResultadoCalculoTempoServico;

  constructor(private service:PdfdownloadService,private route:ActivatedRoute) {
    this.route.paramMap.subscribe(params=>{
      this.resultadoCalculo=window.history.state.resultadoCalculo
    })
  }

  ngOnInit(): void {
  }

  RequisitaPDF(){
    this.service.GerarPDF().subscribe((response:any)=>{
      console.log(response)
      const file=new Blob([response],{type:response.type});
      const blob=window.URL.createObjectURL(file);
      const link = document.createElement('a');
      link.href=blob;
      link.download='Resultado.pdf';
      //link.click();
      link.dispatchEvent(new MouseEvent('click',{
        bubbles:true,
        cancelable:true,
        view:window
      }));
    });
  }
}
