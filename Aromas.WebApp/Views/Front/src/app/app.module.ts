import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import {HttpClientModule} from "@angular/common/http";
import { CadastrarProdutoComponent } from './components/views/product/cadastrar-produto/cadastrar-produto.component';
import { ListarProdutosComponent } from './components/views/product/listar-produtos/listar-produtos.component';
import { AppComponent } from './app.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar'; // toobar
import { MatIconModule } from '@angular/material/icon'; //icon
import { MatListModule } from '@angular/material/list'; //list
import { RegisterUserComponent } from './components/views/user/register-user/register-user.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ListUserComponent } from './components/views/user/list-user/list-user.component';
import { FormsModule } from '@angular/forms';
import { HeaderComponent } from './components/template/header/header.component';
import { CadastrarCategoriaComponent } from './components/views/category/cadastrar-categoria/cadastrar-categoria.component';
import { ListarCategoriaComponent } from './components/views/category/listar-categoria/listar-categoria.component';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';


@NgModule({
  declarations: [
    AppComponent,
    CadastrarProdutoComponent,
    ListarProdutosComponent,
    RegisterUserComponent,
    ListUserComponent,
    HeaderComponent,
    CadastrarCategoriaComponent,
    ListarCategoriaComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    FormsModule,
    MatRadioModule,
    MatTableModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatSlideToggleModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }