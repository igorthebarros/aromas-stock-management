import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarProdutoComponent } from './components/views/product/cadastrar-produto/cadastrar-produto.component';
import { ListarProdutosComponent } from './components/views/product/listar-produtos/listar-produtos.component';

const routes: Routes = [
  {
    path: "",
    component: ListarProdutosComponent,
  },
  {
    path: "product/listar",
    component: ListarProdutosComponent,
  },
  {
    path: "product/cadastrar",
    component: CadastrarProdutoComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
