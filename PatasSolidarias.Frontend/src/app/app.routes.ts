import { Routes } from '@angular/router';

import { PessoaCrudComponent } from './pages/pessoa-crud/pessoa-crud.component';
import { HomeComponent } from './pages/home/home.component';
import { VideoComponent } from './pages/video/video.component';
import { SearchComponent } from './pages/search/search.component';
import { AddComponent } from './pages/add/add.component';

export const Rotas = {
  PessoaCrudComponent: 'pessoa-crud-component',
  HomeComponent: 'home-component',
  VideoComponent: 'video-component',
  SearchComponent: 'search-component',
  AddComponent: 'add-component',
  PessoaCrud: 'pessoa-crud',
  Home: 'home',
  Video: 'video',
  Search: 'search',
  Add: 'add',
}

export const routes: Routes = [
  { path: Rotas.Home, component: HomeComponent },
  { path: Rotas.Video, component: VideoComponent },
  { path: Rotas.Search, component: SearchComponent },
  { path: Rotas.Add, component: AddComponent },
  { path: Rotas.PessoaCrud, component: PessoaCrudComponent },
  { path: Rotas.PessoaCrudComponent, component: PessoaCrudComponent },
  { path: '', redirectTo: Rotas.Home, pathMatch: 'full' },
  { path: '**', redirectTo: Rotas.Home },
];
