import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SidebarSearchComponent } from '../../components/sidebar-search/sidebar-search.component';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterModule, CommonModule, SidebarSearchComponent],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {
  /** guarda o item ativo. Use qualquer rótulo curto */
  ativo = 'home';
  sidebarAberta = false;

  setAtivo(nome: string) {
    this.ativo = nome;
  }

  /** Fecha o sidebar no mobile */
  closeSidebarOnNavigate() {
    if (window.matchMedia('(max-width: 767px)').matches) {
      this.sidebarAberta = false;
    }
  }
}
