import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PerfilComponent } from '../../components/perfil/perfil.component';
import { PerfilEmpresaComponent } from '../../components/perfil/perfil-empresa/perfil-empresa.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-usuario',
  imports: [PerfilEmpresaComponent, CommonModule],
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss']
})
export class UsuarioComponent {
  logado: boolean = true; // Altere para 'true' para simular um usuário logado

  constructor(private router: Router) {
    if (!this.logado) {
      this.router.navigate(['/login']);
    }
  }
}
