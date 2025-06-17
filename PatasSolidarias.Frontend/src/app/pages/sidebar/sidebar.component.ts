import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { lastValueFrom } from 'rxjs';

import { SidebarSearchComponent } from '../../components/sidebar-search/sidebar-search.component';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterModule, CommonModule, SidebarSearchComponent],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  authService = inject(AuthService);
  usuarioAtivo = "";

  ativo = 'home';
  sidebarAberta = false;

  async ngOnInit(): Promise<void> {
    const usuarioAtivo = await this.authService.getUser();
    this.usuarioAtivo = usuarioAtivo?.nome || '';
  }

  setAtivo(nome: string) {
    this.ativo = nome;
  }

  closeSidebarOnNavigate() {
    if (window.matchMedia('(max-width: 767px)').matches) {
      this.sidebarAberta = false;
    }
  }
}
