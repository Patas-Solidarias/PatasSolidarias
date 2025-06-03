import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormCadastroOngComponent } from './form-cadastro-ong.component';

describe('FormCadastroOngComponent', () => {
  let component: FormCadastroOngComponent;
  let fixture: ComponentFixture<FormCadastroOngComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormCadastroOngComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormCadastroOngComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
