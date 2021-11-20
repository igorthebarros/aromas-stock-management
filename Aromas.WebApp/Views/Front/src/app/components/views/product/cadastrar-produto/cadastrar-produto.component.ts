import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProdutoService } from 'src/app/services/produto.service';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-cadastrar-produto',
  templateUrl: './cadastrar-produto.component.html',
  styleUrls: ['./cadastrar-produto.component.css']
})
export class CadastrarProdutoComponent implements OnInit {

  name!: string;
  isInStock!: boolean;
  stockQuantity!: number;
  categoryId!: number;
  categorys!: Category[];

  constructor(private router: Router, 
    private produtoService: ProdutoService, 
    private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.categoryService.list().subscribe((categorys) => {
      this.categorys = categorys;
    })
  }

  cadastrar(): void {
    let product : Product = {
      name: this.name,
      isInStock: this.isInStock,
      stockQuantity: this.stockQuantity,
      categoryId: this.categoryId
    };
    this.produtoService.create(product).subscribe(product => {
      this.router.navigate(["product/list"]);
    });
  }

  cancelar(): void {
    this.router.navigate(["product/list"]);
  }
}
