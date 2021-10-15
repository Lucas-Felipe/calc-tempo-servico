import { PdfdownloadService } from './pdfdownload.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pdfdownload',
  templateUrl: './pdfdownload.component.html',
  styleUrls: ['./pdfdownload.component.scss']
})
export class PDFDownloadComponent implements OnInit {

  constructor(private service:PdfdownloadService) { }

  ngOnInit(): void {
  }

  RequisitaPDF(){
    this.service.GerarPDF();
  }
}
