import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';
import { Router } from "@angular/router";

@Injectable()
export class FornecedorService {

  constructor(private http: Http,
              private route:Router
  ) { }

  getFornecedores() {
    return this.http.get('/api/fornecedores')
      .map(res => res.json());
  }

  //Vamos criar um metodo pra poder madnar ele pro servidor
  create(fornecedor){
    return this.http.post('/api/fornecedores', fornecedor)
      .map(res => res.json())
      .map(id => this.route.navigate(['cardapios/novo/'+id]))
  }
}
