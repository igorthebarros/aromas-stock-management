import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarProdutoComponent } from './components/views/product/cadastrar-produto/cadastrar-produto.component';
import { ListarProdutosComponent } from './components/views/product/listar-produtos/listar-produtos.component';
import { ListUserComponent } from './components/views/user/list-user/list-user.component';
import { RegisterUserComponent } from './components/views/user/register-user/register-user.component';

const routes: Routes = [
  {
    path: "",
    component: ListarProdutosComponent,
  },
  {
    path: "product/list",
    component: ListarProdutosComponent,
  },
  {
    path: "product/register",
    component: CadastrarProdutoComponent,
  },

  { path: 'user/register', component: RegisterUserComponent},
  { path: 'user/list', component: ListUserComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
