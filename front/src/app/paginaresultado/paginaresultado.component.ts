import { ResultadoCalculoTempoServico } from './../models/resultado-calculo-tempo-servico';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-paginaresultado',
  templateUrl: './paginaresultado.component.html',
  styleUrls: ['./paginaresultado.component.scss']
})
export class PaginaresultadoComponent implements OnInit {
  resultadoCalculo!: ResultadoCalculoTempoServico;

  constructor(private route:ActivatedRoute) {
    this.route.paramMap.subscribe(params=>{
      this.resultadoCalculo=window.history.state.resultadoCalculo
    })
  }

  ngOnInit(): void {

  }
}
