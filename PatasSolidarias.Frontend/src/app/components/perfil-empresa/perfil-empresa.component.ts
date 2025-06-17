import { Component } from '@angular/core';
import { CupomListComponent } from '../cupom-list/cupom-list.component';
import { CardOngListComponent } from '../card-ong-list/card-ong-list.component';

@Component({
  selector: 'app-perfil-empresa',
  imports: [CupomListComponent, CardOngListComponent],
  templateUrl: './perfil-empresa.component.html',
  styleUrl: './perfil-empresa.component.scss'
})
export class PerfilEmpresaComponent {
  cupons = [
    { titulo: 'Desconto Ração', status: 'Ativo', validade: '12/12/2025' },
    { titulo: 'Banho Grátis', status: 'Usado', validade: '01/07/2025' },
    { titulo: 'Consulta Vet', status: 'Ativo', validade: '30/08/2025' },
    { titulo: 'Check-up', status: 'Expirado', validade: '01/01/2024' },
    { titulo: 'Vacina Grátis', status: 'Ativo', validade: '10/10/2025' },
    { titulo: 'Brinde Pet', status: 'Ativo', validade: '20/09/2025' },
    { titulo: 'Desconto Banho', status: 'Usado', validade: '05/05/2025' },
  ];

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
