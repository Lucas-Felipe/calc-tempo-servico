import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaginaresultadoComponent } from './paginaresultado.component';

describe('PaginaresultadoComponent', () => {
  let component: PaginaresultadoComponent;
  let fixture: ComponentFixture<PaginaresultadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaginaresultadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaginaresultadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
