import { ListProductInStockComponent } from './components/views/product/list-product-in-stock/list-product-in-stock.component';
import { LoginComponent } from './components/views/auth/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarCategoriaComponent } from './components/views/category/cadastrar-categoria/cadastrar-categoria.component';
import { ListarCategoriaComponent } from './components/views/category/listar-categoria/listar-categoria.component';
import { CadastrarProdutoComponent } from './components/views/product/cadastrar-produto/cadastrar-produto.component';
import { ListarProdutosComponent } from './components/views/product/listar-produtos/listar-produtos.component';
import { ListUserComponent } from './components/views/user/list-user/list-user.component';
import { RegisterUserComponent } from './components/views/user/register-user/register-user.component';
import { UpdateUserComponent } from './components/views/user/update-user/update-user.component';
import { ProductUpdateComponent } from './components/views/product/product-update/product-update.component';
import { RegisterPolicyComponent } from './components/views/policy/register-policy/register-policy.component';
import { ListPolicyComponent } from './components/views/policy/list-policy/list-policy.component';

const routes: Routes = [
  
  { path: "",component: LoginComponent},

  { path: "product/list",component: ListarProdutosComponent},
  { path: "product/register",component: CadastrarProdutoComponent},
  { path: "product/edit/:id",component: ProductUpdateComponent},
  { path: "product/inStock", component: ListProductInStockComponent},
  
  { path: "category/list",component: ListarCategoriaComponent},
  { path: "category/register",component: CadastrarCategoriaComponent},
  
  { path: 'user/register', component: RegisterUserComponent},
  { path: 'user/list', component: ListUserComponent},
  { path: 'user/edit/:id', component: UpdateUserComponent},

  { path: 'policy', component: RegisterPolicyComponent},
  { path: 'policy/list', component: ListPolicyComponent},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
