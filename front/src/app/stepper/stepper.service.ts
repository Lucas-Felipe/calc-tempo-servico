import { CalculoTempoServico } from './../models/calculo-tempo-servico';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class StepperService {
  private apiUrl=environment.apiBaseUrl+environment.CalculoTempoServicoController;

  constructor(private http: HttpClient) {}

  Enviar(calculoTempoServico: CalculoTempoServico) {

    return this.http
      .post(`${this.apiUrl}`, calculoTempoServico, {
        responseType:'blob',
      })
  }

}
