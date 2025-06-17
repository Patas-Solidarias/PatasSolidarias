import { Routes } from '@angular/router';

import { SidebarAddComponent } from './components/sidebar-add/sidebar-add.component';
import { authGuard } from './guards/auth.guard';
import { LayoutCompletoComponent } from './layouts/layout-completo/layout-completo.component';
import { LayoutMenuComponent } from './layouts/layout-menu/layout-menu.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { PessoaCrudComponent } from './pages/pessoa-crud/pessoa-crud.component';
import { UsuarioComponent } from './pages/usuario/usuario.component';
import { VideoComponent } from './pages/video/video.component';

export const Rotas = {
  PessoaCrudComponent: 'pessoa-crud',
  Home: 'home',
  Video: 'video',
  Add: 'add',
  Usuario: 'usuario',
  Login: 'login'
};

export const routes: Routes = [
  {
    path: '',
    component: LayoutMenuComponent,
    canActivate: [authGuard],
    children: [
      { path: Rotas.Home, component: HomeComponent },
      { path: Rotas.Video, component: VideoComponent },
      { path: Rotas.Add, component: SidebarAddComponent },
      { path: Rotas.Usuario, component: UsuarioComponent },
      { path: Rotas.PessoaCrudComponent, component: PessoaCrudComponent },
      { path: '', redirectTo: Rotas.Home, pathMatch: 'full' },
    ]
  },
  {
    path: '',
    component: LayoutCompletoComponent,
    children: [
      { path: Rotas.Login, component: LoginComponent },
    ]
  },
  { path: '**', redirectTo: Rotas.Home }
];
