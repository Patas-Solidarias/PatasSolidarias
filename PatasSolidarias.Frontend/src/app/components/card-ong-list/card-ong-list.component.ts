import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardOngComponent } from '../card-ong/card-ong.component';

@Component({
  selector: 'app-card-ong-list',
  imports: [CardOngComponent, CommonModule],
  templateUrl: './card-ong-list.component.html',
  styleUrl: './card-ong-list.component.scss'
})
export class CardOngListComponent {
  @Input() ongs: any[] = [];

  quantidadePadrao = 4;
  quantidadeVisivel = this.quantidadePadrao;

  mostrarMais() {
    this.quantidadeVisivel = this.ongs.length;
  }

  mostrarMenos() {
    this.quantidadeVisivel = this.quantidadePadrao;
  }
}
