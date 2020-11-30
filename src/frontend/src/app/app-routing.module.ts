import { NgModule } from '@angular/core';
    import { AppComponent } from './app.component';
    import { HttpClientModule } from '@angular/common/http';
    import { HeaderComponent } from './components/header/header.component';
    import { RouterModule, Routes } from '@angular/router';
    import { MainComponent } from './components/main/main.component';

    const routes: Routes = [
        { path: '', redirectTo: 'home', pathMatch: 'full' },
        { path: 'home', component: MainComponent },
        { path: 'restaurante',  loadChildren: './restaurante/restaurante.module#RestauranteModule'},
        { path: 'prato',  loadChildren: './prato/prato.module#PratoModule'},
        { path: 'pedido',  loadChildren: './pedido/pedido.module#PedidoModule'},
      ];

    @NgModule({
        imports: [
            RouterModule.forRoot(routes)
        ],
        exports: [
            RouterModule
        ],
        declarations: []
    })
    export class AppRoutingModule { }