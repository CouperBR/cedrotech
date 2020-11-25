import { Component, OnInit } from '@angular/core';
import { Prato } from 'src/entities/prato';
import { Restaurante } from '../../../../entities/restaurante';

import { DataService } from '../../../data.service';
import {ActivatedRoute, Router} from "@angular/router"

@Component({
  selector: 'app-add-prato',
  templateUrl: './add-prato.component.html',
  styleUrls: ['./add-prato.component.css']
})
export class AddPratoComponent implements OnInit {

  public restaurantes: Restaurante[];
  public nome: string;
  public restauranteId: Number;
  public preco: Number;

  id: number;
  private sub: any;

  constructor(private dataService: DataService, private router: Router, private actRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadRestaurantes();
    this.sub = this.actRoute.params.subscribe(params => {
      this.id = + params['id'];
    });
    if(this.id){
      this.loadPrato(this.id);
    }
  }

  private loadRestaurantes(): void{
    this.dataService.sendGetRequest("restaurante").subscribe((data: any[])=>{
      this.restaurantes = data;
    });
  }

  public async salvar(){
    if(this.nome && this.restauranteId && this.preco){
      let prato = new Prato();
      prato.nome = this.nome;
      prato.preco = this.preco;
      prato.restauranteId = this.restauranteId;
      if(this.id){
        const promise = await this.dataService.sendPutRequest("prato", this.id, JSON.stringify(prato) ).toPromise();
      }
      else{
        const promise = await this.dataService.sendPostRequest("prato", JSON.stringify(prato) ).toPromise();
      }
      this.router.navigate(['/prato'])
    }
    else{
      alert('Preencha todos os campos.');
    }
  }

  public loadPrato(id: Number): void{
    this.dataService.sendGetByIdRequest("prato", this.id).subscribe((data: Prato)=>{
        this.nome = data.nome;
        this.restauranteId = data.restauranteId;
        this.preco = data.preco;
      
    });
  }

}
