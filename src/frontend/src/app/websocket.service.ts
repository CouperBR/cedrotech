import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { io } from 'socket.io-client';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WebsocketService {

  socket;
  constructor() {   }

  setupSocketConnection(): boolean {
    this.socket = io(environment.SOCKET_ENDPOINT);
    this.socket.on('pedido broadcast', (data: string) => {
      return true;
    });
    return false;
  }

  socketEmit(){
    this.socket = io(environment.SOCKET_ENDPOINT);
    this.socket.emit('pedido event', 'Novo pedido');
  }
}
