import { Component, OnInit } from '@angular/core';
import { Pedido } from "../../models/fornecedor";
import { PedidoService } from "../../services/pedido.service";

@Component({
  selector: 'app-pedido-list',
  templateUrl: './pedido-list.component.html',
  styleUrls: ['./pedido-list.component.css']
})
export class PedidoListComponent implements OnInit {

  //properties
  pedidos: Pedido[] = [];
  
    constructor(private pedidoService: PedidoService) { }
  
    ngOnInit() {
  
      this.pedidoService.getPedidos()
        .subscribe(result => this.pedidos = result);
      
    }
  
    //methods
    getTotal(id){
      var total = 0;
  
      this.pedidos.forEach(element => {
        element.itens.forEach(product => {
  
          if(element.pedidoId == id){
            total+= product.preco;
          }
        });
      });    
  
      return total;
    }
  
    getTotalGeral(){
      var total = 0;
    
      this.pedidos.forEach(element => {
        element.itens.forEach(product => {
    
            total+= product.preco;
          
        });
      });    
    
      return total;
    }
  
  }
  
  
  
  