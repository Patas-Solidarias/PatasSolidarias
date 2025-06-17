import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { firstValueFrom } from 'rxjs';

import { usuarioTipos } from '../../../api/e-usuario-tipo';
import { Usuario, usuarioColumns, usuarioForm } from '../../../api/usuario';
import { Field } from '../../components/form/form.types';
import { UsuarioService } from './pessoa-crud.service';

@Component({
  imports: [
    CommonModule,
    FormsModule,
    TableModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    DropdownModule,
    ReactiveFormsModule
  ],
  templateUrl: './pessoa-crud.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PessoaCrudComponent {
  fields: Field<unknown>[] = [];
  usuarioForm = usuarioForm;
  columns = usuarioColumns;
  usuarioTipos = usuarioTipos;
  usuarios: Usuario[] = [];
  usuarioDialog: boolean = false;
  submitted: boolean = false;
  usuarioDialogTitle: string | undefined;
  carregando: unknown;

  constructor(private usuarioService: UsuarioService) { }

  async ngOnInit(): Promise<void> {
    this.configuraCampos();
    await this.loadUsuarios();
  }

  configuraCampos() {
    this.fields = [
      {
        name: 'Nome',
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
      },
      {
        name: 'usuarioTipoId',
        label: 'Tipo de Usuário',
        required: true,
        controlType: 'select',
        options: this.usuarioTipos.map((tipo) => ({
          key: tipo.value,
          description: tipo.label,
        })),
      },
      {
        name: 'descricao',
        label: 'Descrição',
        required: true,
        controlType: 'text',
      },
    ];
  }

  async loadUsuarios() {
    const data = await firstValueFrom(this.usuarioService.getAll());
    this.usuarios = data;
  }

  openNew() {
    this.usuarioDialogTitle = 'Novo Usuário';
    this.usuarioForm.reset();
    this.submitted = false;
    this.usuarioDialog = true;
  }

  editUsuario(usuario: Usuario) {
    this.usuarioDialogTitle = 'Editar Usuário';
    this.usuarioForm.patchValue({
      id: usuario.id,
      nome: usuario.nome,
      email: usuario.email,
      senha: usuario.senha,
      usuarioTipoId: usuario.usuarioTipoId,
    });
    this.usuarioDialog = true;
  }

  async deleteUsuario(usuario: Usuario) {
    if (usuario.id) {
      await firstValueFrom(this.usuarioService.remove(usuario.id));
      await this.loadUsuarios();
    }
  }

  closeDialog() {
    this.usuarioDialog = false;
    this.submitted = false;
  }

  async onSubmit() {
    this.submitted = true;

    if (this.usuarioForm.valid) {
      const usuario: Usuario = {
        id: this.usuarioForm.value.id,
        nome: this.usuarioForm.value.nome,
        email: this.usuarioForm.value.email,
        senha: this.usuarioForm.value.senha,
        usuarioTipoId: this.usuarioForm.value.usuarioTipoId,
        descricao: this.usuarioForm.value.descricao,
      };

      if (usuario.id) {
        await firstValueFrom(this.usuarioService.update(usuario));
      } else {
        await firstValueFrom(this.usuarioService.add(usuario));
      }
      await this.loadUsuarios();
      this.closeDialog();
    }
  }
}
