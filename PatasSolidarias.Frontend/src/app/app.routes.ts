import { Routes } from '@angular/router';

import { PessoaCrudComponent } from './pages/pessoa-crud/pessoa-crud.component';
import { HomeComponent } from './pages/home/home.component';
import { VideoComponent } from './pages/video/video.component';
import { SearchComponent } from './pages/search/search.component';
import { AddComponent } from './pages/add/add.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'video', component: VideoComponent },
  { path: 'search', component: SearchComponent },
  { path: 'add', component: AddComponent },
  { path: 'pessoa-crud', component: PessoaCrudComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' }, 
  { path: '**', redirectTo: 'home' } // opcional para rotas inválidas
];
