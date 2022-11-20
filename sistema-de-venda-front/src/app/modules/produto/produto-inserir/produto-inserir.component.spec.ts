import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdutoInserirComponent } from './produto-inserir.component';

describe('ProdutoInserirComponent', () => {
  let component: ProdutoInserirComponent;
  let fixture: ComponentFixture<ProdutoInserirComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdutoInserirComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdutoInserirComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
