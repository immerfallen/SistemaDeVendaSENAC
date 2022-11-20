import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendaEditarComponent } from './venda-editar.component';

describe('VendaEditarComponent', () => {
  let component: VendaEditarComponent;
  let fixture: ComponentFixture<VendaEditarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendaEditarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendaEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
