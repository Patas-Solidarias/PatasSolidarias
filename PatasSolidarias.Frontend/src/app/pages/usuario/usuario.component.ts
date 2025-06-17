import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PerfilComponent } from '../../components/perfil/perfil.component';
import { PerfilEmpresaComponent } from '../../components/perfil-empresa/perfil-empresa.component';
import { CommonModule } from '@angular/common';
import { PerfilOngComponent } from '../../components/perfil-ong/perfil-ong.component';

@Component({
  selector: 'app-usuario',
  imports: [CommonModule, PerfilEmpresaComponent, PerfilComponent, PerfilOngComponent],
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss']
})
export class UsuarioComponent {
  logado: boolean = true; // Altere para 'true' para simular um usuário logado

  // Simule o tipo do usuario
  tipoUsuario: 'usuario' | 'ong' | 'empresa' = 'usuario'; 
  // tipoUsuario: 'usuario' | 'ong' | 'empresa' = 'empresa'; 
  // tipoUsuario: 'usuario' | 'ong' | 'empresa' = 'ong'; 


  constructor(private router: Router) {
    if (!this.logado) {
      this.router.navigate(['/login']);
    }
  }
}
