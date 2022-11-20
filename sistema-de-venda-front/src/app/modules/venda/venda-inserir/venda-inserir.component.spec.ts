import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendaInserirComponent } from './venda-inserir.component';

describe('VendaInserirComponent', () => {
  let component: VendaInserirComponent;
  let fixture: ComponentFixture<VendaInserirComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendaInserirComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendaInserirComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
