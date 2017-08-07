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

  updade(item){
    return this.http.put('/api/itens/'+item.itemId, item) 
      .map(res => res.json());
  }

  delete(id) {
    return this.http.delete('/api/itens/' + id)
      .map(res => res.json());
  }

  getItem(id) {
    return this.http.get('/api/itens/'+id+'/'+7) //nesse caso eu coloquei o 7 apenas pra quando chegar na controler, ela saber q e pra chamar o Action que tiver alem do parametro id tem um outro paraamentro, so pra separar da outra Achtion
      .map(res => res.json());
  }
}
