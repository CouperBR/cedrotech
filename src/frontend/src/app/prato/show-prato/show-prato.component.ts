import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Prato } from '../../../entities/prato';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-show-prato',
  templateUrl: './show-prato.component.html',
  styleUrls: ['./show-prato.component.css']
})
export class ShowPratoComponent implements OnInit {

  pratos: Prato[];
  public nome: string;

  constructor(private dataService: DataService,private router: Router) { }

  ngOnInit(): void {
    this.loadPratos();
    
  }
  private loadPratos(nome = ""):void{
    this.dataService.sendGetRequest("prato", nome).subscribe((data: any[])=>{
      this.pratos = data;
    });
  }

  public pesquisar(): void{
    this.loadPratos(this.nome)
  }

  public async excluir(id: Number){
    const promise = await this.dataService.sendDeleteRequest("prato", id).toPromise();
    this.loadPratos();
  }

  public editar(id: Number){
    this.router.navigate(['/prato/update/' + id])
  }
}
