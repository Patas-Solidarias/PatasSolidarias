import { CommonModule } from '@angular/common'; 
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
standalone: true,
  selector: 'app-form-login',
  imports: [CommonModule, FormsModule],
  templateUrl: './form-login.component.html',
  styleUrls: ['./form-login.component.scss']
})
export class FormLoginComponent {
  @Output() navegar = new EventEmitter<'cadastro-ong' | 'cadastro-pessoa' | 'cadastro-empresa'>();

  navegarPara(tela: 'cadastro-ong' | 'cadastro-pessoa' | 'cadastro-empresa') {
    this.navegar.emit(tela);
  }
}
