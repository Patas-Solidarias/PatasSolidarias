import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { CommonModule } from '@angular/common'; 

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ToastModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'] // Corrigido aqui
})
export class AppComponent implements OnInit {
  router = inject(Router);

  ngOnInit(): void {
    this.router.initialNavigation(); // Deixa o Angular cuidar do redirecionamento
  }
}
