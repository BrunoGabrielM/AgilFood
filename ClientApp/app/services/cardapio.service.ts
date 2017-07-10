import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';

@Injectable()
export class CardapioService {

  constructor(private http: Http) { }

  // getFornecedores() {
  //   return this.http.get('/api/fornecedores')
  //     .map(res => res.json());
  // }

  //Vamos criar um metodo pra poder madnar ele pro servidor
  create(cardapio){
    return this.http.post('/api/cardapios', cardapio)
      .map(res => res.json());
  }

}
