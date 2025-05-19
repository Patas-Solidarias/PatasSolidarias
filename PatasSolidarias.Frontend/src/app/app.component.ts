import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { SidebarComponent } from './pages/sidebar/sidebar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ToastModule, SidebarComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'] // Corrigido aqui
})
export class AppComponent {
  title = 'Patas solidárias';
}
