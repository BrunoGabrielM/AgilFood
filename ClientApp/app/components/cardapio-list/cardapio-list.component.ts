import { CardapioService } from './../../services/cardapio.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";


@Component({
  selector: 'app-cardapio-list',
  templateUrl: './cardapio-list.component.html',
  styleUrls: ['./cardapio-list.component.css']
})
export class CardapioListComponent implements OnInit {

  cardapios: any[];
  idFornecedor;

  constructor(private cardapioService: CardapioService, 
              private router: ActivatedRoute){

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

 

}
