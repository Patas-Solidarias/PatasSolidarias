import { FormControl, FormGroup } from '@angular/forms';
import { EUsuarioTipo } from './e-usuario-tipo';

export class Usuario {
  id?: number;
  nome?: string;
  email?: string;
  senha?: string;
  criadoDataHora?: Date;
  usuarioTipoId?: EUsuarioTipo;
  descricao?: string;
}

export const usuarioForm: FormGroup = new FormGroup({
  nome: new FormControl(''),
  email: new FormControl(''),
  senha: new FormControl(''),
  usuarioTipoId: new FormControl(0),
  descricao: new FormControl('')
});

export const usuarioColumns = [
  { field: 'nome', header: 'Nome' },
  { field: 'email', header: 'Email' },
  { field: 'usuarioTipoId', header: 'Tipo' },
  { field: 'criadoDataHora', header: 'Criado em' },
  { field: 'descricao', header: 'Descrição' },
];
