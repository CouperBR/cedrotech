import { Component, OnInit } from '@angular/core';
import { DataService } from '../../data.service';
import { Prato } from '../../../entities/prato';
import { Endereco } from 'src/entities/endereco';
import { Pedido } from 'src/entities/pedido';
import {ActivatedRoute, Router} from "@angular/router"

@Component({
  selector: 'app-add-pedido',
  templateUrl: './add-pedido.component.html',
  styleUrls: ['./add-pedido.component.css']
})
export class AddPedidoComponent implements OnInit {

  public pratos: Prato[] = [];
  public pratosAdded: Prato[] = [];
  public total = 0;
  public Cep = "";
  public logradouro = "";
  public complemento = "";
  public bairro = "";
  public localidade = "";
  public uf = "";
  constructor(private dataService: DataService, private router: Router, private actRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.total = 0;
    this.loadPratos();
  }

  async loadPratos(){
    await this.dataService.sendGetRequest("prato").subscribe((data: any[])=>{
      this.pratos = data;
      this.addPrato();
    });
    
  }

  addPrato(){
    this.pratos[0];
    this.pratosAdded.push({
      id : this.pratos[0].id,
      nome: this.pratos[0].nome,
      preco: this.pratos[0].preco,
      quantidade: this.pratos[0].quantidade,
      restauranteId : this.pratos[0].restauranteId,
    });
  }

  removePrato(index){
    this.pratosAdded.splice(index, 1);
    this.somarTotal();
  }

  somarTotal(){
    this.total = 0;
    this.pratosAdded.forEach(element => {
      this.total += element.preco * element.quantidade;
    });
    console.log(this.pratosAdded);
  }

  onChangeSelection(selected, index) {
    this.pratosAdded[index].id = parseInt(selected);
    this.pratosAdded[index].preco = this.pratos.find(x => x.id == this.pratosAdded[index].id).preco;
    this.somarTotal();
  }

  parseFloat(total){
    if(total !== '')
      return parseFloat(total).toFixed(2)
  }

  buscaCEP(){
    this.dataService.sendGetBuscaCepRequest(this.Cep).subscribe((data: Endereco)=>{
      if(data && data.cep != null){
        this.Cep = data.cep;
        this.logradouro = data.logradouro;
        this.complemento = data.complemento;
        this.bairro = data.bairro;
        this.localidade = data.localidade;
        this.uf = data.uf;
      }
    });
  }

  async finalizar(){
    let endereco = new Endereco();
    endereco.bairro = this.bairro;
    endereco.cep = this.Cep;
    endereco.complemento = this.complemento;
    endereco.localidade = this.localidade;
    endereco.logradouro = this.logradouro;
    endereco.uf = this.uf;
    let pedido = new Pedido();
    pedido.pratos = this.pratosAdded;
    pedido.endereco = endereco;
    pedido.total = this.total;
    const promise = await this.dataService.sendPostRequest("pedido", JSON.stringify(pedido) ).toPromise();

    this.router.navigate(['/home'])
  }
}
