import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/models/category';
import { Product } from 'src/app/models/product';
import { CategoryService } from 'src/app/services/category.service';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.css']
})
export class ProductUpdateComponent implements OnInit {

  id!: string;
  product!: Product;
  categoryId!: number;
  categorys!: Category[];

  constructor(
    private service: ProdutoService, 
    private router: Router, 
    private route: ActivatedRoute,
    private serviceCategory: CategoryService) { }

  ngOnInit(): void {
    this.route.snapshot.paramMap.get('id')
    this.service.searchId(this.id).subscribe(product => {
      this.product = product;
    })
  }

  list(): void {
    this.serviceCategory.list().subscribe((categorys) => {
      this.categorys = categorys;
    })
  }

  update(): void{
    this.service.update(this.product).subscribe(() => {
      this.router.navigate(['product/list']);
    });
  }
}
