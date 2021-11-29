import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-list-product-in-stock',
  templateUrl: './list-product-in-stock.component.html',
  styleUrls: ['./list-product-in-stock.component.css']
})
export class ListProductInStockComponent implements OnInit {

  id!: number;
  isInStock!: boolean;
  
  product!: MatTableDataSource<Product>;
  displayedColumns: string[] = [ 'nome', 'quantidade', 'idcategory', 'isInStock', 'acoes'];
  
  constructor(private service: ProdutoService, private router: Router) { }

  ngOnInit(): void {
    this.service.GetProductByInStock().subscribe((product) => {
      this.product = new MatTableDataSource<Product>(product);
    });
  }

  delete(id: number): void {
    this.service.delete(id).subscribe((product) => {
      this.router.navigate(['user/list']);
    });
  }
  
  cadastrarProduto(): void {
    this.router.navigate(["product/register"]);
  }
}
