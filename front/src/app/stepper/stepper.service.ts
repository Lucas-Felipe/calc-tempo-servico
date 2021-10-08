import { take } from 'rxjs/operators';
import { CalculoTempoServico } from './../models/calculo-tempo-servico';
import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';

const api = 'https://localhost:5001';

@Injectable({
  providedIn: 'root',
})
export class StepperService implements OnInit {


  constructor(private http: HttpClient) {}

  ngOnInit(): void {

  }

  Enviar(calculoTempoServico: CalculoTempoServico) {
    return this.http
      .post(`${api}/api/CalculoTempoAposentadoria`, calculoTempoServico,{responseType:'blob'});

  }
}
