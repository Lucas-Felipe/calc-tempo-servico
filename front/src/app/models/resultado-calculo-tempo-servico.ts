import { Pessoa } from "./pessoa";

export interface ResultadoCalculoTempoServico{
  resultadoVerificacaoTempoIntegral:ResultadoVerificacaoTempoIntegral
  resultadoCalculoAbono:ResultadoCalculoAbono
  pessoa:Pessoa
}

export interface ResultadoCalculoAbono{
  frequenciaTotal:number
  averbacaoTotal:number
  tempoFicto:number
  licencaPremio:number
  tempoAverbadoTotal:number
  tempoRestante:number
  pedagio:number
  tempoParaAbono:number
  tempoTotalContribuicao:number
  //tempoGeralServico:number
  dataInicioAbono:number
  mensagem:string
}

export interface ResultadoVerificacaoTempoIntegral{
   contribuicaoTotal:number
   limiteIdade:number
   limiteTempoServico:number
   novoLimiteIdade:number
}
