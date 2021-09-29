import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import {HttpClientModule} from "@angular/common/http";
import { FormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { CadastrarProdutoComponent } from './components/views/product/cadastrar-produto/cadastrar-produto.component';
import { ListarProdutosComponent } from './components/views/product/listar-produtos/listar-produtos.component';

@NgModule({
  declarations: [
    AppComponent,
    CadastrarProdutoComponent,
    ListarProdutosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
