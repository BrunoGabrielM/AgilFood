import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { Router } from "@angular/router";

@Injectable()
export class ItemService {

  constructor(private http: Http,
              private route:Router
  ) { }

  create(item){
    return this.http.post('/api/itens', item)
      .map(res => res.json());
  }

  getItens(cardId) {
    return this.http.get('/api/itens/' + cardId)
      .map(res => res.json())
  }

}
