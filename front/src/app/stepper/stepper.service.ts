import { CalculoTempoServico } from './../models/calculo-tempo-servico';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { take } from 'rxjs/operators';

const api = 'http://localhost:5000';

@Injectable({
  providedIn: 'root',
})
export class StepperService {


  constructor(private http: HttpClient) {}

  Enviar(calculoTempoServico: CalculoTempoServico) {

    return this.http
      .post(`${api}/api/CalculoTempoAposentadoria`, calculoTempoServico, {
        responseType:'blob',
      })
  }

}
