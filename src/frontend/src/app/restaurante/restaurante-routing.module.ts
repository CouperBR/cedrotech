import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddRestauranteComponent } from './add-restaurante/add-restaurante.component';
import { ShowRestauranteComponent } from './show-restaurante/show-restaurante.component';

const routes: Routes = [
        { path: '', component: ShowRestauranteComponent},
        { path: 'add', component: AddRestauranteComponent},
        { path: 'update/:id', component: AddRestauranteComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RestauranteRoutingModule { }
