import { Usuario } from '../../../api/usuario';
import { Field } from '../../../utils/field';
import { UsuarioService } from '../../pages/pessoa-crud/pessoa-crud.service';
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { firstValueFrom } from 'rxjs';
import { Rotas } from '../../app.routes';

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
    ReactiveFormsModule
  ],
  templateUrl: './form-cadastro-empresa.component.html',
  styleUrl: './form-cadastro-empresa.component.scss'
})
export class FormCadastroEmpresaComponent implements OnInit {
  rotas = Rotas;
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
        key: 'descricao',
        label: 'Descrição',
        required: false,
        order: 4,
        controlType: 'input',
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
        descricao: this.usuarioForm.value.descricao,
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
