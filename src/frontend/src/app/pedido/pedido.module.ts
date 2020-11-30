import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PedidoRoutingModule } from './pedido-routing.module';
import { AddPedidoComponent } from './add-pedido/add-pedido.component';
import { FormsModule } from '@angular/forms';
import { NgxMaskModule, IConfig } from 'ngx-mask';
import { ShowPedidosComponent } from './show-pedidos/show-pedidos.component'


@NgModule({
  declarations: [AddPedidoComponent, ShowPedidosComponent],
  imports: [
    CommonModule,
    PedidoRoutingModule,
    CommonModule,
    FormsModule,
    NgxMaskModule.forRoot(),
  ]
})
export class PedidoModule { }
