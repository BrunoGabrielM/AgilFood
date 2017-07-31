import { CardapioService } from './../../services/cardapio.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-cardapio-list',
  templateUrl: './cardapio-list.component.html',
  styleUrls: ['./cardapio-list.component.css']
})
export class CardapioListComponent implements OnInit {

  cardapios: any[];

  cardapio: any = {
    FornecedorId: 0,
  }

  constructor(private cardapioService: CardapioService,
              private route: ActivatedRoute,
              private router: Router,) {
      
    route.params.subscribe(param => this.cardapio.FornecedorId = param['id'])
  }

  ngOnInit() {
    // this.cardapioService.getCardapios()
    //   .subscribe(result => this.cardapios = result);
    
    if(this.cardapio.fornecedorId)
      this.cardapioService.getCardapio(this.cardapio.fornecedorId)
        .subscribe(result => this.cardapio = result);
  }

 

}
