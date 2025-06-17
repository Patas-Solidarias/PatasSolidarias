import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { CardOngListComponent } from '../card-ong-list/card-ong-list.component';

@Component({
  selector: 'app-recentsbar',
  imports: [CommonModule, CardOngListComponent],
  templateUrl: './recentsbar.component.html',
  styleUrl: './recentsbar.component.scss'
})
export class RecentsbarComponent {
 ongs = [
    { nome: 'ONG Patas Felizes', imagem: '' },
    { nome: 'ONG Amor Animal', imagem: '' },
    { nome: 'ONG Peludos Unidos', imagem: '' },
    { nome: 'ONG Vida Animal', imagem: '' },
    { nome: 'ONG Bichos do Bem', imagem: '' },
    { nome: 'ONG Amigos dos Pets', imagem: '' },
    { nome: 'ONG Cuidando Juntos', imagem: '' }
  ];
}
