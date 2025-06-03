import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { CommonModule } from '@angular/common'; 

@Component({
  selector: 'app-layout-completo',
  imports: [RouterOutlet, ToastModule, CommonModule],
  templateUrl: './layout-completo.component.html',
  styleUrl: './layout-completo.component.scss'
})
export class LayoutCompletoComponent {

}
