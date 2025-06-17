import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-publicacoes',
  imports: [CommonModule],
  templateUrl: './publicacoes.component.html',
  styleUrl: './publicacoes.component.scss'
})
export class PublicacoesComponent {
  @Input() publi: any[] = [];
  @Input() quantidadeInicial: number = 2; // 🔥 Quantos aparecem no início
  @Input() incremento: number = 2;

  seguindo = false;

  quantidadeVisivel = 0;

  ngOnInit() {
    this.quantidadeVisivel = this.quantidadeInicial;
  }

  mostrarMais() {
    const scrollY = window.scrollY; // salva a posição atual
    this.quantidadeVisivel = Math.min(
      this.quantidadeVisivel + this.incremento,
      this.publi.length
    );
    setTimeout(() => {
      window.scrollTo({ top: scrollY }); // volta para a mesma posição
    });
  }

  mostrarMenos() {
    this.quantidadeVisivel = this.quantidadeInicial;
  }

  toggleSeguir() {
    this.seguindo = !this.seguindo;
  }

  realizarDoacao() {
    alert('Doação realizada! 💚');
  }
}
