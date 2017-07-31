import { FornecedorService } from './../../services/fornecedor.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-fornecedor-list',
  templateUrl: './fornecedor-list.component.html',
  styleUrls: ['./fornecedor-list.component.css']
})
export class FornecedorListComponent implements OnInit {

  fornecedores: any[];

  constructor(private fornecedorService: FornecedorService) { }

  ngOnInit() {
    this.fornecedorService.getFornecedores()
      .subscribe(result => this.fornecedores = result);
  }

}
