import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-listar-produtos',
  templateUrl: './listar-produtos.component.html',
  styleUrls: ['./listar-produtos.component.css']
})
export class ListarProdutosComponent implements OnInit {

  products: Product[] = [];

  constructor(private service: ProdutoService) { }

  ngOnInit(): void {

    this.service.list().subscribe((products) => {
      this.products = products;
      console.log(products);
    });
  }

}
