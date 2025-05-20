import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { SidebarComponent } from './pages/sidebar/sidebar.component';

import { Rotas } from './app.routes';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ToastModule, SidebarComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'] // Corrigido aqui
})
export class AppComponent implements OnInit {
  router = inject(Router);

  ngOnInit(): void {
    this.router.navigateByUrl(Rotas.PessoaCrudComponent);
  }
}
