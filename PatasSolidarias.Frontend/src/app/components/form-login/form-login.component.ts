import { Component, EventEmitter, inject, OnInit, Output, ViewChild } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';

import { LoginRequest } from '../../../api/login';
import { temValor } from '../../../utils/tem-valor';
import { Rotas } from '../../app.routes';
import { FormComponent } from "../form/form.component";
import { Field } from '../form/form.types';
import { AuthService } from '../../services/auth.service';
import { MessageService } from 'primeng/api';

type TelasLogin = 'login' | 'cadastro-ong' | 'cadastro-empresa' | 'cadastro-pessoa';
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
    ReactiveFormsModule,
    FormComponent
  ]
})
export class FormLoginComponent implements OnInit {
  router = inject(Router);
  authService = inject(AuthService);
  messageService = inject(MessageService);

  @Output() navegar = new EventEmitter<TelasLogin>();

  fields: Field<LoginRequest>[] = [];
  rotas = Rotas;

  @ViewChild(FormComponent) formComponent!: FormComponent<LoginRequest>;

  constructor(
  ) {
    this.configuraCampos();
  }

  private configuraCampos() {
    this.fields = [
      {
        name: 'email',
        label: 'Email',
        required: true,
        controlType: 'text',
      },
      {
        name: 'senha',
        label: 'Senha',
        required: true,
        controlType: 'text',
        password: true,
      },
    ];
  }

  ngOnInit(): void { }

  navegarPara(rota: TelasLogin) {
    this.navegar.emit(rota);
  }

  async onSubmit(): Promise<void> {
    const loginRequest = this.formComponent.obterValorFormulario();

    if (!loginRequest) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Formulário inválido.' });
      return;
    }

    const { email, senha } = loginRequest;
    if (!temValor(email) || !temValor(senha)) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Email e senha são obrigatórios.' });
      return;
    }

    const retorno = await this.authService.login(email, senha);
    if (this.authService.isAuthenticated()) {
      this.router.navigateByUrl(Rotas.Home);
    }
  }
}
