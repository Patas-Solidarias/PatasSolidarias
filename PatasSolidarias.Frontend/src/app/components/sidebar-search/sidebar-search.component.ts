import { CommonModule } from '@angular/common';
import { Component, ElementRef, EventEmitter, HostListener, Input, Output } from '@angular/core';

@Component({
  selector: 'app-sidebar-search',
  imports: [CommonModule],
  templateUrl: './sidebar-search.component.html',
  styleUrl: './sidebar-search.component.scss'
})
export class SidebarSearchComponent {
  @Input() ativo = false;                   // <-- recebe do pai
  @Output() ativarBusca = new EventEmitter<void>();
  @Output() fecharBusca = new EventEmitter<void>();

  mostrarBusca = false;

  constructor(private eRef: ElementRef) {}

  toggleBusca() {
    this.mostrarBusca = !this.mostrarBusca;
    this.mostrarBusca ? this.ativarBusca.emit()
                      : this.fecharBusca.emit();
  }

  @HostListener('document:click', ['$event'])
  handleClickOutside(event: MouseEvent) {
    if (!this.eRef.nativeElement.contains(event.target) && this.mostrarBusca) {
      this.mostrarBusca = false;
      this.fecharBusca.emit();
    }
  }
}
