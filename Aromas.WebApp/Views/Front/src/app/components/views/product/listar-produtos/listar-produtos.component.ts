import { Category } from 'src/app/models/category';
import { Component, OnInit} from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { pipe } from 'rxjs';
import { Product } from 'src/app/models/product';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-listar-produtos',
  templateUrl: './listar-produtos.component.html',
  styleUrls: ['./listar-produtos.component.css']
})
export class ListarProdutosComponent implements OnInit {

  id!: number;
  
  product!: MatTableDataSource<Product>;
  displayedColumns: string[] = [ 'nome', 'quantidade', 'idcategory', 'isInStock', 'acoes'];
  
  constructor(private service: ProdutoService, private router: Router) { }

  ngOnInit(): void {
    this.service.list().subscribe((product) => {
      this.product = new MatTableDataSource<Product>(product);
    });
  }
  
  delete(id: number): void {
    this.service.delete(id).subscribe((product) => {
      // this.product = new MatTableDataSource<Product>(product);
      this.router.navigate(['user/list']);
    });
  }
  
  cadastrarProduto(): void {
    this.router.navigate(["product/register"]);
  }

  filtrar(event: Event) {
    const filtro = (event.target as HTMLInputElement).value;
    this.product.filter = filtro.trim().toLowerCase();
  }  
  
}

