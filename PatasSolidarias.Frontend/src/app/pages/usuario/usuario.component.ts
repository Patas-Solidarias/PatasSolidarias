import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PerfilComponent } from '../../components/perfil/perfil.component';
import { CommonModule } from '@angular/common'; 

@Component({
  selector: 'app-usuario',
  imports: [PerfilComponent, CommonModule],
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss']
})
export class UsuarioComponent {
  logado: boolean = false; // Altere para 'true' para simular um usuário logado

  constructor(private router: Router) {
    if (!this.logado) {
      this.router.navigate(['/login']);
    }
  }
}
