import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { EUsuarioTipo } from '../../../api/e-usuario-tipo';
import { Usuario } from '../../../api/usuario';
import { temValor } from '../../../utils/tem-valor';
import { PerfilEmpresaComponent } from '../../components/perfil-empresa/perfil-empresa.component';
import { PerfilOngComponent } from '../../components/perfil-ong/perfil-ong.component';
import { PerfilComponent } from '../../components/perfil/perfil.component';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-usuario',
  imports: [CommonModule, PerfilEmpresaComponent, PerfilComponent, PerfilOngComponent],
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss']
})
export class UsuarioComponent implements OnInit {
  authService = inject(AuthService);
  logado: boolean = true;

  EUsuarioTipo = EUsuarioTipo;
  tipoUsuario: EUsuarioTipo = EUsuarioTipo.Doador;
  usuarioAtivoNome?: string;

  async ngOnInit(): Promise<void> {
    const usuarioAtivo = await this.authService.obterUsuarioAtivo();
    if (!temValor(usuarioAtivo)) {
      this.logado = false;
      return;
    }

    this.usuarioAtivoNome = usuarioAtivo.nome;
    this.tipoUsuario = usuarioAtivo.usuarioTipoId!;
  }

  constructor(private router: Router) {
  }
}
