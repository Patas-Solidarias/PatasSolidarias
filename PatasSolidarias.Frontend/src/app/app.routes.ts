import { Routes } from '@angular/router';

import { LayoutCompletoComponent } from './layouts/layout-completo/layout-completo.component';
import { LayoutMenuComponent } from './layouts/layout-menu/layout-menu.component';

import { PessoaCrudComponent } from './pages/pessoa-crud/pessoa-crud.component';
import { HomeComponent } from './pages/home/home.component';
import { VideoComponent } from './pages/video/video.component';
import { UsuarioComponent } from './pages/usuario/usuario.component';
import { LoginComponent } from './pages/login/login.component'; // login aqui

export const Rotas = {
  PessoaCrudComponent: 'pessoa-crud',
  Home: 'home',
  Video: 'video',
  Usuario: 'usuario',
  Login: 'login'
};

export const routes: Routes = [
  {
    path: '',
    component: LayoutMenuComponent,
    children: [
      { path: Rotas.Home, component: HomeComponent },
      { path: Rotas.Video, component: VideoComponent },
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
      { path: '', redirectTo: 'home', pathMatch: 'full' },
    ]
  },
  { path: '**', redirectTo: Rotas.Home }
];
