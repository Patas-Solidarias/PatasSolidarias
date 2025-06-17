import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-cupom-list',
  imports: [CommonModule],
  templateUrl: './cupom-list.component.html',
  styleUrl: './cupom-list.component.scss'
})
export class CupomListComponent {
  @Input() cupons: any[] = [];

  quantidadeVisivel = 6;

  mostrarMais() {
    this.quantidadeVisivel = this.cupons.length;
  }

  mostrarMenos() {
    this.quantidadeVisivel = 6;
  }
}
