import { RouterModule } from '@angular/router';
import { StepperService } from './stepper/stepper.service';
import { AppRoutingModule } from './app-routing.module';
import { MatStepperModule } from '@angular/material/stepper';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import localePt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatNativeDateModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { MatTableModule } from '@angular/material/table';
import { DialogBoxComponent } from './dialog-box/dialog-box.component';
import { StepperComponent } from './stepper/stepper.component';
import { HttpClientModule } from '@angular/common/http';
import { PDFDownloadComponent } from './pdfdownload/pdfdownload.component';
import { PaginaresultadoComponent } from './paginaresultado/paginaresultado.component';


registerLocaleData(localePt, 'pt');

@NgModule({
  declarations: [AppComponent, DialogBoxComponent, StepperComponent, PDFDownloadComponent,
    PaginaresultadoComponent],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    MatStepperModule,
    MatInputModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatDatepickerModule,
    MatDialogModule,
    MatIconModule,
    MatNativeDateModule,
    MatRadioModule,
    MatTableModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule,

  ],
  providers: [StepperService,PaginaresultadoComponent],
  bootstrap: [AppComponent],
})
export class AppModule {}
