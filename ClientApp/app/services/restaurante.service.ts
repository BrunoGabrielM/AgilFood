import { Injectable } from '@angular/core';
import { Http } from '@angular/http'; 
import 'rxjs/add/operator/map';

@Injectable()
export class RestauranteService {

  constructor(private http: Http) { }

  getCardapios() {
    return this.http.get('/api/cardapios')
      .map(res => res.json());
  }
}
