import { Frequencia } from './../stepper/stepper.component';
import { Component, Inject, Optional } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-box',
  templateUrl: './dialog-box.component.html',
  styleUrls: ['./dialog-box.component.scss']
})
export class DialogBoxComponent {

  action:string;
  local_data:any;

  AddFormGroup: FormGroup= this._formBuilder.group({
    ano:[, Validators.required],
    tempoLiquido:[, Validators.required],
  });;
  UpdateFormGroup: FormGroup= this._formBuilder.group({
    idFrequencia:[],
    ano:[,Validators.required],
    tempoLiquido:[, Validators.required]
  });;

  constructor(
    public dialogRef: MatDialogRef<DialogBoxComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: Frequencia,private _formBuilder: FormBuilder) {

    this.local_data = {...data};
    this.action = this.local_data.action;
    console.log("imprimindo local_data1:",this.local_data)
    console.log("imprimindo action:",this.action)
  }

  doAction(){
    console.log("imprimindo addformgroup:",this.AddFormGroup.value)
     console.log("imprimindo updateformgroup:",this.UpdateFormGroup.value)
    console.log("imprimindo local_data2:",this.local_data)

    if(this.action=="Add")
    {
      this.dialogRef.close({event:this.action,data:this.AddFormGroup.value});
    }
    else
    {
      this.UpdateFormGroup.value.idFrequencia=this.local_data.idFrequencia
      this.dialogRef.close({event:this.action,data:this.UpdateFormGroup.value})
    }
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }

}
