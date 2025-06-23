import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { lastValueFrom } from 'rxjs';

import { SidebarSearchComponent } from '../../components/sidebar-search/sidebar-search.component';
import { AuthService } from '../../services/auth.service';
import { Usuario } from '../../../api/usuario';
import { EUsuarioTipo } from '../../../api/e-usuario-tipo';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterModule, CommonModule, SidebarSearchComponent],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  EUsuarioTipo = EUsuarioTipo;
  authService = inject(AuthService);
  usuarioAtivo?: Usuario;

  ativo = 'home';
  sidebarAberta = false;

  async ngOnInit(): Promise<void> {
    this.usuarioAtivo = await this.authService.obterUsuarioAtivo();
  }

  setAbaAtiva(nome: string) {
    this.ativo = nome;
  }

  closeSidebarOnNavigate() {
    if (window.matchMedia('(max-width: 767px)').matches) {
      this.sidebarAberta = false;
    }
  }
}
