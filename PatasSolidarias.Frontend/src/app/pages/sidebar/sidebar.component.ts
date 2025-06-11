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
  ativo: string = 'home'; // padrão
  sidebarAberta = false;

  setAtivo(nome: string) {
    this.ativo = nome;
  }

  /** Fecha a barra depois que o usuário navega (opcional, só para mobile) */
  closeSidebarOnNavigate() {
    if (window.matchMedia('(max-width: 767px)').matches) {
      this.sidebarAberta = false;
    }
  }
}
