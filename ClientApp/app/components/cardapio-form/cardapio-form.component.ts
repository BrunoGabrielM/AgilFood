import { RestauranteService } from './../../services/restaurante.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cardapio-form',
  templateUrl: './cardapio-form.component.html',
  styleUrls: ['./cardapio-form.component.css']
})
export class CardapioFormComponent implements OnInit {

  cardapios: any[]; 
  itens: any[]; 
  restaurante: any= {};

  constructor(private restauranteService: RestauranteService) { }

  ngOnInit() {
    this.restauranteService.getCardapios().subscribe(cardapios => {
      this.cardapios = cardapios;

      //Sempre boa pratica jogar um log pra ver se esta tudo funcionando ate o momento [BabySteps]
        console.log("CARDAPIOS", this.cardapios);
   });
  }

  onCardapioChange(){
    var selectCardapio= this.cardapios.find(c => c.CardapioId == this.restaurante.cardapio);
    this.itens= selectCardapio ? selectCardapio.itens : []; //para quando nao for selecionada nenhum cardapio, nao trazer lixo

     console.log("RESTAURANTE", this.restaurante);
  } 
}
