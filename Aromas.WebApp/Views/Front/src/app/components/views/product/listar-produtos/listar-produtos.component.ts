import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-listar-produtos',
  templateUrl: './listar-produtos.component.html',
  styleUrls: ['./listar-produtos.component.css']
})
export class ListarProdutosComponent implements OnInit {

  //products: Product[] = [];

  product!: MatTableDataSource<Product>;
  displayedColumns: string[] = [ 'nome', 'quantidade', 'idcategory', 'acoes'];

  constructor(private service: ProdutoService, private router: Router) { }

  // ngOnInit(): void {

  //   this.service.list().subscribe((products) => {
  //     this.products = products;
  //     console.log(products);
  //   });
  // }

  ngOnInit(): void {
    this.service.list().subscribe((product) => {
      this.product = new MatTableDataSource<Product>(product);
    });
  }

  cadastrarProduto(): void {
    this.router.navigate(["product/register"]);
  }
}
