import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-listar-categoria',
  templateUrl: './listar-categoria.component.html',
  styleUrls: ['./listar-categoria.component.css']
})
export class ListarCategoriaComponent implements OnInit {

  category!: MatTableDataSource<Category>;
  
  displayedColumns: string[] = [ 'nome', 'subC', 'acoes'];

  constructor(private service: CategoryService, private router: Router) { }

  ngOnInit(): void {
    this.service.list().subscribe((category) => {
      this.category = new MatTableDataSource<Category>(category);
    });
  }

  cadastrarCategory(): void {
    this.router.navigate(["category/register"]);
  }
}
