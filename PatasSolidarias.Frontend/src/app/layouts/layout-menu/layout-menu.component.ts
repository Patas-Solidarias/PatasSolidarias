import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { SidebarComponent } from '../../pages/sidebar/sidebar.component';
import { CommonModule } from '@angular/common'; 

@Component({
  selector: 'app-layout-menu',
    imports: [RouterOutlet, ToastModule, SidebarComponent, CommonModule],
  templateUrl: './layout-menu.component.html',
  styleUrl: './layout-menu.component.scss'
})
export class LayoutMenuComponent {

}
