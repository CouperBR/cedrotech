import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RestauranteRoutingModule } from './restaurante-routing.module';
import { ShowRestauranteComponent } from './show-restaurante/show-restaurante.component';
import { AddRestauranteComponent } from './add-restaurante/add-restaurante.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ShowRestauranteComponent, AddRestauranteComponent],
  imports: [
    CommonModule,
    RestauranteRoutingModule,
    FormsModule
  ]
})
export class RestauranteModule { }
