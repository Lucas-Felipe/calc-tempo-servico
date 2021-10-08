import { ResultadoCalculoAbono, ResultadoVerificacaoTempoIntegral } from './../models/resultado-calculo-tempo-servico';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

const api = 'https://localhost:5001';

@Injectable({
  providedIn: 'root'
})
export class PdfdownloadService {


  constructor(private http: HttpClient) { }

  GerarPDF(){
    return this.http
      .get(`${api}/api/PdfDownload`,{responseType:'blob'})

  }
}
