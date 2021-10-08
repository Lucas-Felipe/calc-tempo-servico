import { PaginaresultadoComponent } from './paginaresultado/paginaresultado.component';
import { StepperComponent } from './stepper/stepper.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'',
    redirectTo:'/inicio',
    pathMatch:'full'
  },
  {
    path:'inicio',
    component:StepperComponent
  },
  {
    path:'paginaresultado',
    component:PaginaresultadoComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
