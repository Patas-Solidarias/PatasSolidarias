import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card-ong',
  imports: [],
  templateUrl: './card-ong.component.html',
  styleUrl: './card-ong.component.scss'
})
export class CardOngComponent {
  @Input() nome: string = 'Nome da ONG';
  @Input() imagem: string = 'assets/user.png';
  seguindo: boolean = false;

  toggleSeguir() {
    this.seguindo = !this.seguindo;
  }
}
