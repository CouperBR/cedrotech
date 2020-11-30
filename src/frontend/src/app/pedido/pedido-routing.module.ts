import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddPedidoComponent } from './add-pedido/add-pedido.component';
import { ShowPedidosComponent } from './show-pedidos/show-pedidos.component';

const routes: Routes = [
  {path: '', component: AddPedidoComponent},
  {path: 'show', component: ShowPedidosComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PedidoRoutingModule { }
