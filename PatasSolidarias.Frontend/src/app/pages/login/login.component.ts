import { Component } from '@angular/core';
import { FormLoginComponent } from '../../components/form-login/form-login.component';
import { FormCadastroOngComponent } from '../../components/form-cadastro-ong/form-cadastro-ong.component';
import { FormCadastroUsuarioComponent } from '../../components/form-cadastro-usuario/form-cadastro-usuario.component';
import { FormCadastroEmpresaComponent } from '../../components/form-cadastro-empresa/form-cadastro-empresa.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [
    CommonModule, // se necessário
    FormLoginComponent,
    FormCadastroOngComponent,
    FormCadastroUsuarioComponent,
    FormCadastroEmpresaComponent
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  // Tela inicial é sempre o login
  tela: 'login' | 'cadastro-ong' | 'cadastro-empresa' | 'cadastro-pessoa' = 'login';

  trocarTela(tela: 'login' | 'cadastro-ong' | 'cadastro-empresa' | 'cadastro-pessoa') {
    this.tela = tela;
  }
}
