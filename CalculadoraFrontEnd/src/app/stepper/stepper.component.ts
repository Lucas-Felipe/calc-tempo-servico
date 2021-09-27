import { StepperService } from './stepper.service';
import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';
import { JsonpClientBackend } from '@angular/common/http';

export interface Pessoa {
  idPessoa:number,
  genero:number,
  dataNascimento:Date
}

export interface Averbado {
  idAverbado:number,
  quantidadeDias:number
}

export type averbacoes=Averbado[];

export interface Frequencia {
  idFrequencia:number,
  ano:number,
  tempoLiquido:number,
  action:string
}
export type frequencias=Frequencia[];

const DATA_FREQ: frequencias=[]
const DATA_AVER: averbacoes=[]

@Component({
  selector: 'app-stepper',
  templateUrl: './stepper.component.html',
  styleUrls: ['./stepper.component.scss'],
})
export class StepperComponent {

  isEditable = true;
  displayedColumns: string[] = ['Ano','tempoLiquido','action'];
  dataSource = DATA_FREQ;
  pessoa?:Pessoa;
  averbado=DATA_AVER;

  firstFormGroup: FormGroup= this._formBuilder.group({
    genero:[,Validators.required],
    dataNascimento:[Date, Validators.required]
  });;

  secondFormGroup: FormGroup= this._formBuilder.group({
    quantidadeDias: [,Validators.required],
    // licencaCtrl:[,Validators.required]
  });;

  // thirdFormGroup: FormGroup= this._formBuilder.group({
  //   page3Ctrl:[,Validators.maxLength(1)]
  // });;

  @ViewChild(MatTable,{static:true}) table?: MatTable<any>;

  constructor(public dialog: MatDialog,private _formBuilder: FormBuilder,
    private service:StepperService) {

  }

 openDialog(action:any,obj:any)
  {
    obj.action = action;
    const dialogRef = this.dialog.open(DialogBoxComponent,
      {
        width: '250px',
        data:obj
      });

    dialogRef.afterClosed().subscribe(result =>
    {
      if(result.event == 'Add')
      {

        this.addRowData(result.data);
      }
      else if(result.event == 'Update')
      {

        this.updateRowData(result.data);
      }
      else if(result.event == 'Delete')
      {
        this.deleteRowData(result.data);
      }
    });
  }

  addRowData(row_obj:Frequencia)
  {
    this.dataSource.push(
    {
      idFrequencia:this.dataSource.length+1,
      ano:row_obj.ano,
      tempoLiquido:row_obj.tempoLiquido,
      action:row_obj.action
    });
    this.table?.renderRows();
  }

  updateRowData(row_obj:Frequencia)
  {

      this.dataSource=this.dataSource.filter(value=>
      {
        if(value.idFrequencia == row_obj.idFrequencia)
        {
          value.ano = row_obj.ano;
          value.tempoLiquido = row_obj.tempoLiquido;
        }
        return true;
      });
  }

  deleteRowData(row_obj:Frequencia)
  {

    this.dataSource = this.dataSource.filter((value)=>
    {
      return value.idFrequencia != row_obj.idFrequencia;
    });
  }

  novoEnviar()
  {
    this.pessoa=this.firstFormGroup.getRawValue() as Pessoa;
    this.averbado.push(this.secondFormGroup.getRawValue() as Averbado)


    this.service.Enviar(`{"pessoa":
      ${JSON.stringify(this.pessoa)},
      "frequencias:"${JSON.stringify(this.dataSource,["ano","tempoLiquido"])},
      "averbacoes:"${JSON.stringify(this.averbado)}}`
    ).subscribe(sucess=>console.log(sucess),
    error=>console.log(error))

  }

}
