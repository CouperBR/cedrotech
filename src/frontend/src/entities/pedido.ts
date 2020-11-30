import { Endereco } from './endereco';
import { Prato } from './prato';

export class Pedido {  
    id: Number; 
    endereco: Endereco;
    pratos: Prato[];
    total: Number;
 }  