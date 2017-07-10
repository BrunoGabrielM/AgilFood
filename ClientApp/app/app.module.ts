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



@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        CardapioFormComponent,
        FornecedorFormComponent
    ],
    imports: [
        FormsModule,
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'cardapios/novo/:id', component: CardapioFormComponent },
            { path: 'fornecedores/novo', component: FornecedorFormComponent },
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
      CardapioService
    ]
})
export class AppModule {
}
