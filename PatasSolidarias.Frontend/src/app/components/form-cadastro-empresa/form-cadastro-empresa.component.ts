import { CommonModule } from '@angular/common';
import { Component, EventEmitter, inject, OnInit, Output } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { firstValueFrom } from 'rxjs';

import { usuarioTipos } from '../../../api/e-usuario-tipo';
import { Usuario } from '../../../api/usuario';
import { temValor } from '../../../utils/tem-valor';
import { Rotas } from '../../app.routes';
import { AuthService } from '../../services/auth.service';
import { FormComponent } from '../form/form.component';
import { Field } from '../form/form.types';

@Component({
  selector: 'app-form-cadastro-empresa',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    TableModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    DropdownModule,
    ReactiveFormsModule,
    FormComponent
  ],
  templateUrl: './form-cadastro-empresa.component.html',
  styleUrl: './form-cadastro-empresa.component.scss'
})
export class FormCadastroEmpresaComponent implements OnInit {
  authService = inject(AuthService);
  mensagemService = inject(MessageService);

  @Output() voltar = new EventEmitter<void>();

  usuarioTipos = usuarioTipos;
  fields: Field<Usuario>[] = [];
  submitted: boolean = false;
  rotas = Rotas;

  constructor() { }

  ngOnInit(): void {
    this.configuraCampos();
  }

  voltarParaLogin() {
    this.voltar.emit();
  }

  configuraCampos() {
    this.fields = [
      {
        name: 'nome',
        label: 'Nome',
        required: true,
        controlType: 'text',
      },
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
      {
        name: 'confirmarSenha',
        label: 'Confirmar Senha',
        required: true,
        controlType: 'text',
        password: true,
      },
      {
        name: 'descricao',
        label: 'Descrição',
        required: true,
        controlType: 'text',
      },
      {
        name: 'acoes',
        controlType: 'form footer buttons'
      }
    ];
  }

  async onSubmit(usuario: Usuario) {
    if (!temValor(usuario)) {
      this.mensagemService.add({
        severity: 'error',
        summary: 'Erro',
        detail: 'Preencha todos os campos obrigatórios.'
      });
      return;
    }

    await this.authService.register(usuario);
    this.voltarParaLogin();
  }
}
