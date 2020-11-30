import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddPedidoComponent } from './add-pedido/add-pedido.component';

const routes: Routes = [
  {path: '', component: AddPedidoComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PedidoRoutingModule { }
