import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-cadastrar-categoria',
  templateUrl: './cadastrar-categoria.component.html',
  styleUrls: ['./cadastrar-categoria.component.css']
})
export class CadastrarCategoriaComponent implements OnInit {


  name!: string;
  subCategory!: string;
  
  constructor(private service: CategoryService, private router: Router) { }

  ngOnInit(): void {
  }

  cadastrar(): void {
    let category : Category = {
      name: this.name,
      subCategory: this.subCategory,
    };
    this.service.create(category).subscribe(category => {
      console.log(category);
      this.router.navigate(["category/list"]);
    });
  }

  cancelar(): void {
    this.router.navigate(["category/list"]);
  }

}
