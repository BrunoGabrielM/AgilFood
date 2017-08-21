import { Auth } from './../../services/auth.service';
import { CardapioService } from './../../services/cardapio.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";


@Component({
  selector: 'app-cardapio-list',
  templateUrl: './cardapio-list.component.html',
  styleUrls: ['./cardapio-list.component.css']
})
export class CardapioListComponent implements OnInit {

  cardapios: any[];
  idFornecedor;
  idCardapio;
  
  idItem;
  //@ViewChild('i.itemId') itemId: number;

  constructor(private cardapioService: CardapioService, 
              private router: ActivatedRoute,
              private auth: Auth){

      router.params.subscribe(param => this.idFornecedor = param['id'])
  }

  ngOnInit() {
 
    // if(this.cardapio.FornecedorId){
    //   this.cardapioService.getCardapio(this.cardapio.fornecedorId)
    //     .subscribe(result => this.cardapio = result);
      
    //   console.log('Caiu no If');
    // }

    // else{
    //   this.cardapioService.getCardapios()
    //     .subscribe(result => this.cardapios = result);

    //   console.log('Caiu no Else');
    // }

    this.cardapioService.getCardapio(this.idFornecedor)
        .subscribe(result => this.cardapios = result);
        
  }

  deleteItem() {
    if (confirm("Tem certeza?")) {
      this.cardapioService.deleteItem(this.idItem)
        .subscribe(x => console.log(x));
    }
  }

 
}
