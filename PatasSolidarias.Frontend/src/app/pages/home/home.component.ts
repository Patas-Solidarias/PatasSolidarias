import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { PublicacoesComponent } from '../../components/publicacoes/publicacoes.component';

@Component({
  selector: 'app-home',
  imports: [CommonModule, PublicacoesComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
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
      imagemPostagem: 'assets/post2.jpg',
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
      imagemPostagem: 'assets/post2.jpg',
      descricao: 'Campanha de castração solidária. Participe!',
      seguindo: true
    }
  ];
}
