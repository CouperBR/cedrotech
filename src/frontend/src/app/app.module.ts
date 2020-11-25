import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './components/header/header.component';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './components/main/main.component';
import { ShowPratoComponent } from './components/prato/show-prato/show-prato.component';
import { AddPratoComponent } from './components/prato/add-prato/add-prato.component';
import { ShowRestauranteComponent } from './components/restaurante/show-restaurante/show-restaurante.component';
import { AddRestauranteComponent } from './components/restaurante/add-restaurante/add-restaurante.component';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: MainComponent },
  { path: 'prato', component: ShowPratoComponent},
  { path: 'prato/add', component: AddPratoComponent},
  { path: 'prato/update/:id', component: AddPratoComponent},
  { path: 'restaurante', component: ShowRestauranteComponent},
  { path: 'restaurante/add', component: AddRestauranteComponent},
  { path: 'restaurante/update/:id', component: AddRestauranteComponent},
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MainComponent,
    ShowPratoComponent,
    AddPratoComponent,
    ShowRestauranteComponent,
    AddRestauranteComponent
  ],
  imports: [
    BrowserModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    HttpClientModule,
    RouterModule.forRoot(routes),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
