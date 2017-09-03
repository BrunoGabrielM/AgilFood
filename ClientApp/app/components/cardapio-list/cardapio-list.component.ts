import { ItemService } from './../../services/item.service';
import { Item, SavePedido } from './../../models/fornecedor';
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

  itens: Item[] = [];
  item: Item = {
    itemId: 0,
    descricao: '',
    nome: '',
    codigo: '',
    preco: 0,
  };
  pedido: SavePedido = {
    pedidoId: 0,
    nomeUsuario: '',
    emailUsuario: '',
    itens: [],
  };

  profile: any;

  constructor(private cardapioService: CardapioService,
    private router: ActivatedRoute,
    private auth: Auth) {

    router.params.subscribe(param => this.idFornecedor = param['id'])

    //Para pegar as coisas do profile
    this.profile = JSON.parse(localStorage.getItem('profile'));
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



  //CrudItensPedido
  addCarrinho(product, productId) {
    console.log(product);
    console.log(productId);

    this.itens.push(product);
    this.pedido.itens.push(productId);
  }

  deleteCarrinho(product, productId) {
    console.log(product);

    var index = this.itens.indexOf(product);
    this.itens.splice(index, 1);

    var index = this.pedido.itens.indexOf(productId);
    this.pedido.itens.splice(index, 1);
  }

  enviarPedido() {

    this.pedido.emailUsuario = this.profile.email;
    this.pedido.nomeUsuario = this.profile.name;
    console.log(this.pedido);

    this.cardapioService.postPedido(this.pedido)
      .subscribe(x => console.log(x));
  }

  getTotalGeral() {
    var total = 0;

    this.itens.forEach(product => {

      total += product.preco;

    });


    return total;
  }
}
