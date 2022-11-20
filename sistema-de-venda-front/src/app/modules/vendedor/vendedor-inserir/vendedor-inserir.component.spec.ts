import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendedorInserirComponent } from './vendedor-inserir.component';

describe('VendedorInserirComponent', () => {
  let component: VendedorInserirComponent;
  let fixture: ComponentFixture<VendedorInserirComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendedorInserirComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendedorInserirComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
