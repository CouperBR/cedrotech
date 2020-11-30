import { Component, OnInit } from '@angular/core';

import { DataService } from './data.service';
import { WebsocketService } from './websocket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'frontend';

  constructor(private wsService: WebsocketService){}

  ngOnInit() {
  }

}
