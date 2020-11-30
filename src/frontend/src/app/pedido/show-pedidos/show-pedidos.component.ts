import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { io } from 'socket.io-client';
import { WebsocketService } from 'src/app/websocket.service';
import { Pedido } from 'src/entities/pedido';
import { DataService } from 'src/app/data.service';

@Component({
  selector: 'app-show-pedidos',
  templateUrl: './show-pedidos.component.html',
  styleUrls: ['./show-pedidos.component.css']
})
export class ShowPedidosComponent implements OnInit {
  pedidos: Pedido[];
  socket;
  constructor(private wsService: WebsocketService, private dataService: DataService) { }

  ngOnInit(): void {
    this.dataService.sendGetPedidoRequest("pedido").subscribe((data: Pedido[])=>{
      this.pedidos = data;
      console.log(this.pedidos);
    });
    this.socket = io(environment.SOCKET_ENDPOINT);
    this.socket.on('pedido broadcast', (data: string) => {
      this.dataService.sendGetPedidoRequest("pedido").subscribe((data: Pedido[])=>{
        this.pedidos = data;
      });
    });
  }

}
