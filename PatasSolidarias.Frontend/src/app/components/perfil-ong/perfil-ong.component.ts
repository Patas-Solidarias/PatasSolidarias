import { Component } from '@angular/core';
import { PublicacoesComponent } from '../publicacoes/publicacoes.component';

@Component({
  selector: 'app-perfil-ong',
  imports: [PublicacoesComponent],
  templateUrl: './perfil-ong.component.html',
  styleUrl: './perfil-ong.component.scss'
})
export class PerfilOngComponent {
  publicacoes = [
    {
      nome: 'Nome do usuário',
      fotoPerfil: 'assets/usu.png',
      data: '17 de junho de 2025',
      imagemPostagem: 'assets/post.jpg',
      descricao: 'Estamos arrecadando ração para nossos bichinhos!',
      seguindo: false
    },
    {
      nome: 'Nome do usuário',
      fotoPerfil: 'assets/usu.png',
      data: '15 de junho de 2025',
      imagemPostagem: 'assets/post2.jpg',
      descricao: 'Campanha de castração solidária. Participe!',
      seguindo: true
    },
    {
      nome: 'Nome do usuário',
      fotoPerfil: 'assets/usu.png',
      data: '15 de junho de 2025',
      imagemPostagem: 'assets/post.jpg',
      descricao: 'Campanha de castração solidária. Participe!',
      seguindo: true
    },
    {
      nome: 'Nome do usuário',
      fotoPerfil: 'assets/usu.png',
      data: '15 de junho de 2025',
      imagemPostagem: 'assets/post2.jpg',
      descricao: 'Campanha de castração solidária. Participe!',
      seguindo: true
    }
  ];
}
