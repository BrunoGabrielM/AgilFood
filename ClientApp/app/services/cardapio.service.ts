import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';
import { Router } from "@angular/router";

@Injectable()
export class CardapioService {

  constructor(private http: Http,
              private route:Router
  ) {}

  getCardapios() {
    return this.http.get('/api/cardapios')
      .map(res => res.json());
  }

  getCardapio(fornId) {
    return this.http.get('/api/cardapios/' + fornId)
      .map(res => res.json())
  }

  create(cardapio, FornecedorId){
    return this.http.post('/api/cardapios', cardapio)
      .map(res => res.json())
      .map(id => this.route.navigate(['itens/novo/'+id+'/'+FornecedorId]));
  }

  updade(cardapio){
    return this.http.put('/api/cardapios', + cardapio.id, cardapio)
      .map(res => res.json());
  }

  delete(id) {
    return this.http.delete('/api/cardapios/' + id)
      .map(res => res.json());
  }

  deleteItem(id){
    return this.http.delete('/api/itens/'+id)
      .map(res => res.json());
  }

}
