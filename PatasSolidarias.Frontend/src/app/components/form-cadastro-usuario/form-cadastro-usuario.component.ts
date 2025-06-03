import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Field } from '../../../utils/field';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import { firstValueFrom } from 'rxjs';
import { Usuario } from '../../../api/usuario';
import { UsuarioService } from '../../pages/pessoa-crud/pessoa-crud.service';

@Component({
  selector: 'app-form-cadastro-usuario',
  standalone: true,
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
  templateUrl: './form-cadastro-usuario.component.html',
  styleUrl: './form-cadastro-usuario.component.scss'
})

export class FormCadastroUsuarioComponent implements OnInit {
  @Output() voltar = new EventEmitter<void>();

  usuarioForm!: FormGroup;
  fields: Field<unknown>[] = [];
  usuarios: Usuario[] = [];
  submitted: boolean = false;
  erroCadastro: boolean = false;

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit(): void {
    this.configuraCampos();
    this.createForm();
  }

  voltarParaLogin() {
    this.voltar.emit();
  }

  configuraCampos() {
    this.fields = [
      new Field<string>({
        key: 'nome',
        label: 'Nome',
        required: true,
        order: 1,
        controlType: 'input',
        type: 'text',
      }),
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
      })
    ];
  }

  createForm() {
    this.usuarioForm = new FormGroup(
      {
        nome: new FormControl('', [
          Validators.required,
          Validators.minLength(3),
          Validators.pattern(/^[A-Za-zÀ-ÿ\s]+$/)
        ]),
        email: new FormControl('', [
          Validators.required,
          Validators.email
        ]),
        senha: new FormControl('', [
          Validators.required,
          Validators.minLength(6)
        ]),
        confirmarSenha: new FormControl('', [
          Validators.required
        ]),
        descricao: new FormControl(''),
        usuarioTipoId: new FormControl('doador')
      },
      {
        validators: [this.senhasIguaisValidator.bind(this)]  // ✅ usa array e bind
      }
    );
  }

  senhasIguaisValidator(formGroup: AbstractControl): { [key: string]: any } | null {
    const senha = formGroup.get('senha')?.value;
    const confirmarSenha = formGroup.get('confirmarSenha')?.value;
    return senha === confirmarSenha ? null : { senhasDiferentes: true };
  }

  // Adicionar id do tipo empresa
  async onSubmit() {
    this.submitted = true;
    this.erroCadastro = false; // limpar erro anterior

    if (this.usuarioForm.valid) {
      const usuario: Usuario = {
        id: this.usuarioForm.value.id,
        nome: this.usuarioForm.value.nome,
        email: this.usuarioForm.value.email,
        senha: this.usuarioForm.value.senha,
        usuarioTipoId: this.usuarioForm.value.usuarioTipoId,
      };

      try {
        await firstValueFrom(this.usuarioService.add(usuario));
        this.voltarParaLogin(); // redireciona se deu certo
      } catch (error) {
        this.erroCadastro = true; // ativa mensagem de erro
      }
    } else {
      this.erroCadastro = true;
    }
  }

}
