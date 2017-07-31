import { ItemService } from './services/item.service';
import { CardapioService } from './services/cardapio.service';
import { FornecedorService } from './services/fornecedor.service';
import { FormsModule } from '@angular/forms'; 
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';

import { RestauranteService } from "./services/restaurante.service";
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { CardapioFormComponent } from "./components/cardapio-form/cardapio-form.component";
import { FornecedorFormComponent } from './components/fornecedor-form/fornecedor-form.component';
import { ItemFormComponent } from "./components/item-form/item-form.component";
import { FornecedorListComponent } from './components/fornecedor-list/fornecedor-list.component';
import { CardapioListComponent } from './components/cardapio-list/cardapio-list.component';




@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        CardapioFormComponent,
        FornecedorFormComponent,
        ItemFormComponent,
        FornecedorListComponent,
        CardapioListComponent
    ],
    imports: [
        FormsModule,
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'cardapios/novo/:id', component: CardapioFormComponent },
            { path: 'itens/novo/:id', component: ItemFormComponent },
            { path: 'fornecedores/novo', component: FornecedorFormComponent },
            { path: 'fornecedores', component: FornecedorListComponent },
            { path: 'cardapios', component: CardapioListComponent },
            { path: 'cardapios/:fornId', component: CardapioListComponent },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    //para o servico
    providers: [
      RestauranteService,
      FornecedorService,
      CardapioService,
      ItemService
    ]
})
export class AppModule {
}
