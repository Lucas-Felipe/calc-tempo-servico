import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { take } from 'rxjs/operators';

const api = 'http://localhost:5000';

@Injectable({
  providedIn: 'root'
})
export class PdfdownloadService {

  constructor(private http: HttpClient) { }

  GerarPDF(){
    return this.http
      .get(`${api}/api/DownloadPdf`, {
        headers: { 'content-type': 'application/json' },
      })
      .pipe(take(1));
  }
}
