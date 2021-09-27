import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {take} from "rxjs/operators"

const api='https://localhost:5001';

@Injectable({
  providedIn: 'root'
})
export class StepperService {

  constructor(private http:HttpClient) { }

  Enviar(stringf:any){
    console.log(stringf)
    return this.http.post(
      `${api}/api/CalculoTempoAposentadoria`,stringf,{'headers':{'content-type':'application/json'}})
      .pipe(take(1))
  }
}
