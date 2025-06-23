import { EUsuarioTipo } from './e-usuario-tipo';

export class UsuarioResponse {
  id?: number;
  nome?: string;
  email?: string;
  criadoDataHora?: Date;
  usuarioTipoId?: EUsuarioTipo;
  descricao?: string;
}
