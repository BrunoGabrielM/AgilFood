import { CardapioService } from './../../services/cardapio.service';
import { RestauranteService } from './../../services/restaurante.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-cardapio-form',
  templateUrl: './cardapio-form.component.html',
  styleUrls: ['./cardapio-form.component.css']
})
export class CardapioFormComponent implements OnInit {

  cardapio : any = {
    nome: '',
    idFornecedor: 12  
  }

  constructor(private cardapioService: CardapioService, private route: ActivatedRoute) {
      route.params.subscribe(param => this.cardapio.FornecedorId = param['id'])
   }

  ngOnInit() {
    
  }

  submit(){
    this.cardapioService.create(this.cardapio)
      .subscribe(x => console.log(x));
  }
}
