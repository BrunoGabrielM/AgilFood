import { FornecedorService } from './../../services/fornecedor.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-fornecedor-form',
  templateUrl: './fornecedor-form.component.html',
  styleUrls: ['./fornecedor-form.component.css']
})
export class FornecedorFormComponent implements OnInit {

  //Variavei
  fornecedor: any = {
    nome: '',
    id: 0
  }
  //precisamos inicializar para poder fazer o binding

  constructor(private fornecedorService: FornecedorService) { }


  ngOnInit() {
    
  }

  submit(){
    this.fornecedorService.create(this.fornecedor)
      .subscribe(x => console.log(x));
  }
    
}
