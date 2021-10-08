import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PDFDownloadComponent } from './pdfdownload.component';

describe('PDFDownloadComponent', () => {
  let component: PDFDownloadComponent;
  let fixture: ComponentFixture<PDFDownloadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PDFDownloadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PDFDownloadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
