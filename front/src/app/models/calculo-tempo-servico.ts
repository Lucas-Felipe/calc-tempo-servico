import { Averbado } from './averbado';
import { Frequencias } from './frequencia';
import { Pessoa } from './pessoa';

export interface CalculoTempoServico{

  pessoa: Pessoa;

  frequencias: Frequencias;

  averbacoes: number;

  licencaPremioEmDias:number;

}
