import { ItemService } from './../../services/item.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-item-form',
  templateUrl: './item-form.component.html',
  styleUrls: ['./item-form.component.css']
})
export class ItemFormComponent implements OnInit {

  //Properties
  item: any = {
    nome: '',
    preco: 0,
    CardapioId: 0
  }

  constructor(private itemService: ItemService,
              private route: ActivatedRoute){

      route.params.subscribe(param => this.item.CardapioId = param['id'])  
  }

  ngOnInit() {
    
  }

  submit(){
    this.itemService.create(this.item)
      .subscribe(x => console.log(x));
  }

}
