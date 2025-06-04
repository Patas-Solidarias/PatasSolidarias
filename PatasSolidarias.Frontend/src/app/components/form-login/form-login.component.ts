import { Component, EventEmitter, inject, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';

import { Field } from '../../../utils/field';
import { Rotas } from '../../app.routes';
import { AuthService } from '../../services/auth.service';
import { LoginRequest } from '../../../api/login';

type telasLogin = 'login' | 'cadastro-ong' | 'cadastro-empresa' | 'cadastro-pessoa';
@Component({
  selector: 'app-form-login',
  styleUrl: './form-login.component.scss',
  templateUrl: "./form-login.component.html",
  imports: [
    FormsModule,
    TableModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    DropdownModule,
    ReactiveFormsModule
  ]
})
export class FormLoginComponent implements OnInit {
  router = inject(Router);
  @Output() navegar = new EventEmitter<telasLogin>()

  form: FormGroup = new FormGroup<any>({
    email: new FormControl(''),
    senha: new FormControl(''),
  });
  fields: Field<unknown>[] = [];

  rotas = Rotas;

  constructor(
    private authService: AuthService,
  ) {
    this.configuraCampos();
  }

  private configuraCampos() {
    this.fields = [
      new Field<string>({
        key: 'email',
        label: 'Email',
        required: true,
        order: 2,
        controlType: 'input',
        type: 'email',
      }),
      new Field<string>({
        key: 'senha',
        label: 'Senha',
        required: true,
        order: 3,
        controlType: 'input',
        type: 'password',
      }),
    ];
  }

  ngOnInit(): void { }

  navegarPara(rota: telasLogin) {
    this.navegar.emit(rota);
  }

  async onSubmit(): Promise<void> {
    if (!this.form.valid) {
      return;
    }

    const { email, senha } = this.form.value;
    const retorno = await this.authService.login(email, senha);
    if (this.authService.isAuthenticated()) {
      this.router.navigateByUrl(Rotas.Home);
    }
  }

  onCancel(): void {
    this.form.reset();
  }
}
