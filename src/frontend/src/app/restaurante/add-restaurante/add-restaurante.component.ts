import { Component, OnInit } from '@angular/core';
import { Restaurante } from '../../../entities/restaurante';

import { DataService } from '../../data.service';
import {ActivatedRoute, Router} from "@angular/router"

@Component({
  selector: 'app-add-restaurante',
  templateUrl: './add-restaurante.component.html',
  styleUrls: ['./add-restaurante.component.css']
})
export class AddRestauranteComponent implements OnInit {

  id: number;
  private sub: any;

  public nome: string;

  constructor(private dataService: DataService, private router: Router, private actRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.sub = this.actRoute.params.subscribe(params => {
      this.id = + params['id'];
    });
    if(this.id){
      this.loadRestaurante(this.id);
    }
  }

  public loadRestaurante(id: Number): void{
    this.dataService.sendGetByIdRequest("restaurante", this.id).subscribe((data: Restaurante)=>{
        this.nome = data.nome;
    });
  }

  public async salvar(){
      let restaurante = new Restaurante();
      restaurante.nome = this.nome;
      if(this.id){
        const promise = await this.dataService.sendPutRequest("restaurante", this.id, JSON.stringify(restaurante) ).toPromise();
      }
      else{
        const promise = await this.dataService.sendPostRequest("restaurante", JSON.stringify(restaurante) ).toPromise();
      }
      this.router.navigate(['/restaurante'])
  }

}
