import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Restaurante } from '../../../entities/restaurante';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-show-restaurante',
  templateUrl: './show-restaurante.component.html',
  styleUrls: ['./show-restaurante.component.css']
})
export class ShowRestauranteComponent implements OnInit {

  restaurantes: Restaurante[];
  public nome: string;

  constructor(private dataService: DataService,private router: Router) { }

  ngOnInit(): void {
    this.loadRestaurantes();
  }

  private loadRestaurantes(nome = ""): void{
    this.dataService.sendGetRequest("restaurante",nome).subscribe((data: any[])=>{
      this.restaurantes = data;
    });
  }

  public pesquisar(): void{
    this.loadRestaurantes(this.nome)
  }

  public async excluir(id: Number){
    const promise = await this.dataService.sendDeleteRequest("restaurante", id).toPromise();
    this.loadRestaurantes();
  }

  public editar(id: Number){
    this.router.navigate(['/restaurante/update/' + id])
  }

}
